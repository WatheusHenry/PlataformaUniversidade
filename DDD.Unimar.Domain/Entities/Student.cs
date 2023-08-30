using DDD.Unimar.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Unimar.Domain.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime DateRegister { get; set; }
        public bool Active { get; set; }
        //public List<Address>? Adresses { get; set; }
        public List<Discipline> Disciplines { get; set; }
    }
}
