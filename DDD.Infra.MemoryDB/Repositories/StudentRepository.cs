using DDD.Infra.MemoryDB.Interfaces;
using DDD.Unimar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDB.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApiContext _context;

        // Dependency Injection
        public StudentRepository(ApiContext context)
        {
            _context = context;
        }
        public List<Student> GetStudents()
        {
            var list = _context.Students.Include(x => x.Disciplines).ToList();
            return list;
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.Find(id);
        }

        public void InsertStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                //LOG
                throw;
            }
        }

        public void UpdateStudent(Student student)
        {
            try
            {
                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                //LOG
                throw;
            }
        }
        
        public void DeleteStudent(Student student)
        {
            try
            {
                _context.Set<Student>().Remove(student);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
