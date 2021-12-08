using System;

namespace SkysCodeFirst.Data
{
    public class Invoice
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime DueDateUtc { get; set; }

    }
}