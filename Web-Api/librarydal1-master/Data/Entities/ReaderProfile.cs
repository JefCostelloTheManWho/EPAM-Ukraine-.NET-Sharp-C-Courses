using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace Data.Entities
{
    public class ReaderProfile : BaseEntity
    {
        /// <summary>
        /// ReaderProfile Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Reader navigation.
        /// </summary>
        public Reader Reader { get; set; }

        /// <summary>
        /// Reader Id.
        /// </summary>
        public int ReaderId { get; set; }

        /// <summary>
        /// Reader address 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Reader phone
        /// </summary>
        public string Phone { get; set; }

    }
}
