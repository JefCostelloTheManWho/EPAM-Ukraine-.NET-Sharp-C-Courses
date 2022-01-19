using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class CardModel
    {
        public int Id { get; set; }

        public int ReaderId { get; set; }

        public ICollection<int> BooksIds { get; set; }
        
        public DateTime Created { get; set; } = DateTime.Now;
    }
}