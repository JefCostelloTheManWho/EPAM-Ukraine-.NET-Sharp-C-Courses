using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace Data.Entities
{
    public class Reader : BaseEntity
    {
        /// <summary>
        /// Reader id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Reader's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Reader email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// ReadersProvile navigation.
        /// </summary>
        public ReaderProfile ReaderProfile { get; set; }

        /// <summary>
        /// Cards' navigation
        /// </summary>
        public ICollection<Card> Cards { get; set; }

    }
}
