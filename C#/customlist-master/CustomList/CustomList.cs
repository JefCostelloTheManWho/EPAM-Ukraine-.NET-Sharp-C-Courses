using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomList
{
    public class CustomList<T> : IList<T>
    {
        /// <summary>
        /// The property return first element of list 
        /// </summary>
        public Item<T> Head { get; set; }
        private readonly T[] array;

        /// <summary>
        /// The property return number of elements contained in the CustomList
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the IList is read-only.
        /// Make it always false
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Constructor that gets params T as parameter
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when values is null</exception>
        /// <param name="values"></param>
       
        public CustomList(params T[] values)
        {
            array = values;
            if (values.Length != 0)
            {
                Item<T> item = new Item<T>(array[0]);
                Head = item;
            }
            Count = array.Length;
        }

        /// <summary>
        /// Constructor that gets Ienumerable collection as parameter
        /// </summary>
        ///<exception cref="ArgumentNullException">Thrown when values is null</exception>
        /// <param name="values"></param>
        public CustomList(IEnumerable<T> values)
        {
            array = values.ToArray();
            if (array.Length != 0)
            {
                Item<T> item = new Item<T>(array[0]);
                Head = item;
            }
            Count = array.Length;
        }

        /// <summary>
        /// Get or set data at the position.
        /// </summary>
        /// <param name="index">Position</param>
        /// <exception cref="IndexOutOfRangeException">Throw when index is less than 0 or greater than Count - 1</exception>
        public T this[int index]
        {
            get
            {   
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }

        /// <summary>
        ///  Adds an object to the end of the CustomList.
        /// </summary>
        /// <param name="data">Object that should be added in the CustomList</param>
        /// <exception cref="ArgumentNullException">Throws when you try to add null</exception>
        public void Add(T item)
        {
            if(item == null)
            {
                throw new ArgumentNullException($"{item} is null");
            }
            Item<T> node = new Item<T>(item);
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Head.Next = node;
                Count++;
            }
        }
        /// <summary>
        /// Removes all elements from the CustomList
        /// </summary>
        public void Clear()
        {
            foreach(var item in array.ToList())
            {
                array.ToList().Remove(item);
            }
            Count = 0;
            Head = null;
        }
        /// <summary>
        /// Determines whether an element is in the CustomList
        /// </summary>
        /// <param name="item">Object we check to see if it is on the CustomLIst</param>
        /// <returns>True if the element exists in the CustomList, else false</returns>
        public bool Contains(T item)
        {
            if (array.Contains(item))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the CustomList.
        /// </summary>
        /// <param name="item"> The object to remove from the CustomList</param>
        /// <returns>True if item is successfully removed; otherwise, false. This method also returns
        ///     false if item was not found in the CustomList.</returns>
        /// <exception cref="ArgumentNullException">Throws when you try to remove null</exception>
        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException($"{item} is null");
            }
            if (array.Contains(item) && Head.Next != null)
            {
                Head = Head.Next;
                return true;
            }
            else if (array.Contains(item) && Head.Next == null)
            {
                Head = null;
                Count = 0;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first
        ///     occurrence within the CustomList.
        /// </summary>object whose ind
        /// <returns>The zero-based index of the first occurrence of item within the entire CustomList,
        ///    if found; otherwise, -1.</returns>
        public int IndexOf(T item)
        {
            if (array.Contains(item))
            {
                return Array.IndexOf(array,item);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Inserts an element into the CustomList at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when index is less than 0 or greater than Count - 1</exception>
        /// <exception cref="ArgumentNullException">Thrown when item is null</exception>
        public void Insert(int index, T item)
        {
            array[index] = item;
        }

        /// <summary>
        /// Removes the element at the specified index of the CustomList.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when index is less than 0 or greater than Count - 1</exception>
        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                Count--;
            }
        }

        /// <summary>
        /// Copies the entire CustomList to a compatible one-dimensional array, starting at the beginning of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements copied
        ///     from CustomList</param>
        /// <param name="arrayIndex">The zero-based index in the source System.Array at which
        ///   copying begins.</param>
        ///   <exception cref="ArgumentNullException">Array is null.</exception>
        ///   <exception cref="ArgumentException">The number of elements in the source CustomList is greater
        ///    than the number of elements that the destination array can contain</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            this.array.CopyTo(array,arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the CustomList.
        /// </summary>
        /// <returns></returns>
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
