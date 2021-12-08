using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkysCodeFirst.Data
{
    public class Person
    {
        public int Id { get; set; }

        [Required]   // not nullable
        [MaxLength(100)] // nvarchar (100)
        public string Name { get; set; }

        public int Age { get; set; }

        public int ShoeSize { get; set; }

        public County County { get; set; }

        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}