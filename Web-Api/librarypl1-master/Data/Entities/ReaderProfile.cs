using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class ReaderProfile
    {
        [Key]
        public int ReaderId { get; set; }

        public Reader Reader { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}