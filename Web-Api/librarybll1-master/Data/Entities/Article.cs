using System;

namespace Data.Entities
{
    public class Article : BaseEntity
    {
        public string Headline { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}