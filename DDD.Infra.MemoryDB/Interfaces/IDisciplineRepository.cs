using DDD.Unimar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDB.Interfaces
{
    public interface IDisciplineRepository
    {
        public List<Discipline> GetDisciplines();
        public Discipline GetDisciplineById(int id);
        public void InsertDiscipline(Discipline discipline);
        public void UpdateDiscipline(Discipline discipline);
        public void DeleteDiscipline(Discipline discipline);
    }
}
