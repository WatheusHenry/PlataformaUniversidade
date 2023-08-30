using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Unimar.Domain.Entities
{
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool Available { get; set; }
        public bool Ead { get; set; }
    }
}
