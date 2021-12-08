using System.Collections.Generic;

namespace SkysCodeFirst.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}