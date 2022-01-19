using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Data.Entities
{
    public class Book : BaseEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Book's title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Book's year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Book's author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Histories navigation.
        /// </summary>
        public ICollection<History> Cards { get; set; }
    }
}