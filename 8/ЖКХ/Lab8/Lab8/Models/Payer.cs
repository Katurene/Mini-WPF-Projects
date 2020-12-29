using System;

namespace Lab8.Models
{
    public class Payer
    {
        public int PayerId { get; set; }
        public String FullName { get; set; }
        public String Street { get; set; }
        public int House { get; set; }
        public int Flat { get; set; }
        public decimal Payment { get; set; }
    }
}
