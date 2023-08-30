using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Unimar.Domain.ValueObjects
{
    public class Address
    {
        public string Logradouro { get; set; }
        public string Number { get; set; }
        public string Cep { get; set; }
    }
}
