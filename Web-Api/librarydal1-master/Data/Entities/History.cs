using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class History : BaseEntity
    {
        /// <summary>
        /// History Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Card navigation.
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// Card id.
        /// </summary>
        public int CardId { get; set; }

        /// <summary>
        /// Book navigation.
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// Book id.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Take time.
        /// </summary>
        public DateTime TakeDate { get; set; }

        /// <summary>
        /// Return time.
        /// </summary>
        public DateTime ReturnDate { get; set; }

    }
}
