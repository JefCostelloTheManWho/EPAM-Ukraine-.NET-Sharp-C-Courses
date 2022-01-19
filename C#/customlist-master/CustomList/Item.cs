using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
   public class Item<T>
    {
        public T Data { get; set; }
        public Item<T> Next { get; set; }
        public Item(T data)
        {
            throw new NotImplementedException();
        }

    }
}
