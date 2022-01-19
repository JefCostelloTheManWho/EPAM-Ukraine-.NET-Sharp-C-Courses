using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class History : BaseEntity
    {
        public int Id { get; set; }
        public Card Card { get; set; }
        public int CardId { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        
        public DateTime TakeDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}