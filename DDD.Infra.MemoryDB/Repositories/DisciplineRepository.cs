using DDD.Infra.MemoryDB.Interfaces;
using DDD.Unimar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Infra.MemoryDB.Repositories
{
    public class DisciplineRepository : IDisciplineRepository
    {
        private readonly ApiContext _context;

        // Dependency Injection
        public DisciplineRepository(ApiContext context)
        {
            _context = context;
        }

        public List<Discipline> GetDisciplines()
        {
            var list = _context.Disciplines.ToList();
            return list;
        }

        public Discipline GetDisciplineById(int id)
        {
            return _context.Disciplines.Find(id);
        }

        public void InsertDiscipline(Discipline discipline)
        {
            try
            {
                _context.Disciplines.Add(discipline);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateDiscipline(Discipline discipline)
        {
            try
            {
                _context.Entry(discipline).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                //LOG
                throw;
            }
        }

        public void DeleteDiscipline(Discipline discipline)
        {
            try
            {
                _context.Disciplines.Remove(discipline);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
