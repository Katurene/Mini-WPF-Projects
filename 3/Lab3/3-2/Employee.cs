using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2
{
    class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }

        public override string ToString() => $"{Name} {Salary} {Position} {City} {Street} {HouseNumber}";
    }
}
