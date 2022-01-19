using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Card : BaseEntity
    {
        public DateTime Created { get; set; }

        public int ReaderId { get; set; }
        public Reader Reader { get; set; }

        public ICollection<History> Books { get; set; } = new List<History>();
    }
}
