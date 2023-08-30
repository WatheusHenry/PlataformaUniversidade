using DDD.Unimar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDB.Interfaces
{
    public interface IStudentRepository
    {
        public List<Student> GetStudents();
        public Student GetStudentById(int id);
        public void InsertStudent(Student student);
        public void UpdateStudent(Student student);
        public void DeleteStudent(Student student);
    }

    

}
