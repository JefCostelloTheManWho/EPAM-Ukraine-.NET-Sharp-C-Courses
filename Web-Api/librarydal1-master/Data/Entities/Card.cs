using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Card : BaseEntity
    {
        /// <summary>
        /// Card id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Created Datetime
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Reader id.
        /// </summary>
        public int ReaderId { get; set; }

        /// <summary>
        /// Reader navigation
        /// </summary>
        public Reader Reader { get; set; }

        /// <summary>
        /// Readers' navigation.
        /// </summary>
        public ICollection<History> Books { get; set; }

    }
}
