using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomArray
{
    public class CustomArray<T> : IEnumerable<T>
    {
        private T[] array;

        public int First { get; set; }
        /// <summary>
        /// Should return last index of array
        /// </summary>
        public int Last { get; }
        /// <summary>
        /// Should return length of array
        /// <exception cref="ArgumentException">Thrown when value was smaller than 0</exception>
        /// </summary>
        public int Length
        {
            get
            {
                if (Array.Length < 0)
                {
                    throw new ArgumentException($"{Array.Length} is 0") as SystemException;
                }
                else
                {
                    return array.Length;
                }
            }
            private set => System.Array.Resize(ref array, value);
        }
        /// <summary>
        /// Should return array 
        /// </summary>
        public T[] Array
        {
            get
            {
                return array;
            }
        }
        /// <summary>
        /// Constructor with first index and length
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="length">Length</param>    
        public CustomArray(int first, int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException($"{length} is 0");
            }
            this.First = first;
            this.Last = first + length - 1;
            array = new T[length];
        }
        /// <summary>
        /// Constructor with first index and collection
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Collection</param>
        ///  <exception cref="NullReferenceException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when count is smaler than 0</exception>
        public CustomArray(int first, IEnumerable<T> list)
        {
            if (list is null)
            {
                throw new NullReferenceException() as SystemException;
            }
            else if (!list.Any())
            {
                throw new ArgumentException($"{list} count is 0");
            }
            array = list.ToArray();
            this.First = first;
        }
        /// <summary>
        /// Constructor with first index and params
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Params</param>
        ///  <exception cref="ArgumentNullException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when list without elements </exception>
        public CustomArray(int first, params T[] list)
        {
            if (list is null)
            {
                throw new ArgumentNullException($"{list} is null");
            }
            else if (list.Length <= 0)
            {
                throw new ArgumentException($"{list} length is 0");
            }
            array = list;
            this.First = first;
            this.Last = int.Parse(array.Last().ToString());
        }

        /// <summary>
        /// Indexer with get and set  
        /// </summary>
        /// <param name="item">Int index</param>        
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when index out of array range</exception> 
        /// <exception cref="ArgumentNullException">Thrown in set  when value passed in indexer is null</exception>
        public T this[int item]
        {
            get
            {
                if (item < First || item >= Array.Length)
                {
                    throw new ArgumentException($"{item} out of array range");
                }
                else if (array[item - First] is null)
                {
                    throw new ArgumentNullException($"{array[item]} value is null");
                }
                return array[item-First];
            }
            set
            {
                if(item-First < First || item - First >= Array.Length)
                {
                    throw new ArgumentException($"{item} out of array range");
                }
                if (item < First || item >= Array.Length)
                {
                    throw new ArgumentException($"{item} out of array range");
                }
                else if (array[item - First] is null)
                {
                    throw new ArgumentNullException($"{array[item - First]} value is null");
                }
                array[item - First] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return array.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
