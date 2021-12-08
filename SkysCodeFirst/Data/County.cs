using System.ComponentModel.DataAnnotations;

namespace SkysCodeFirst.Data
{
    public class County
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string ContactPerson { get; set; }

    }
}