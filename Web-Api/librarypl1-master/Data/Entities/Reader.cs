using System.Collections.Generic;

namespace Data.Entities
{
    public class Reader : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public ReaderProfile ReaderProfile { get; set; }
        
        public ICollection<Card> Cards { get; set; }
    }
}
