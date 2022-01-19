using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomList.Tests
{
    [TestFixture]
    public class Tests
    {
        #region Low
        [TestCase(1, 2, 3, 4, 5, 6)]
        [TestCase(0)]
        public void Count_Get_ShouldReturnCorrectValue(params int[] elements)
        {
            //arrange
            CustomList<int> list = new CustomList<int>(elements);

            //act
            var expected = elements.Length;
            var actual = list.Count;

            //assert
            Assert.AreEqual(expected, actual, message: "Length get property works incorrectly");
            Assert.AreEqual(elements[0], list[0], message: "Get indexer works incorrectly ");
        }
        [Test]
        public void Count_Return0()
        {
            // arrange
            int zero = 0;
            //act
            CustomList<int> list = new CustomList<int>();
            //assert 
            Assert.AreEqual(list.Count, zero, message: "Count get property works incorrectly");

        }

        [Test]
        public void Clear_ReturnCount0()
        {
            //arrange
            CustomList<int> list = new CustomList<int>(1, 2, 3);
            Item<int> expectedHead = null;

            //act
            list.Clear();
            int count = list.Count;
            var actualHead = list.Head;

            //arrange
            Assert.Multiple(() =>
            {
                Assert.AreEqual(0, count, message: "Clear method works incorrectly ");
                Assert.AreEqual(expectedHead, actualHead, message: "Clear method works incorrectly ");
            });
        }

        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, true)]
        [TestCase(100, new int[] { 1, 2, 3, 4, 5 }, false)]
        [TestCase(0, new int[] { }, false)]
        public void Contains_TrueOrFalseReturned(int elementsToFind, int[] elements, bool expected)
        {
            //arrange
            CustomList<int> list = new CustomList<int>(elements);

            //act
            var isContains = list.Contains(elementsToFind);

            //arrange
            Assert.AreEqual(expected, isContains, message: "Contains method works incorrectly ");
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 2, 6 }, 1)]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5, 6 }, -1)]
        [TestCase(0, new int[] { }, -1)]
        public void IndexOf_Element_ExpectedPositionReturned(int element, int[] elements, int expected)
        {
            //arrange
            CustomList<int> list = new CustomList<int>(elements);

            //act
            var position = list.IndexOf(element);

            //arrange
            Assert.AreEqual(expected, position, message: "IndexOf method works incorrectly");
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, 4, true)]
        [TestCase(10, new int[] { 1, 2, 3, 4, 5 }, 5, false)]
        [TestCase(15, new int[] { 11, 4, 5 }, 3, false)]
        [TestCase(-1, new int[] { -1, 2, -1, 4, 5 }, 4, true)]
        [TestCase(99, new int[] { -1, 2, -1, 4, 100 }, 5, false)]
        [TestCase(1, new int[] { 1 }, 0, true)]
        public void Remove_Element_ReturnedExpectedCount(int elementToRemove, int[] elements, int expectedCount, bool expectedBool)
        {
            //arrange
            CustomList<int> list = new CustomList<int>(elements);

            //act
            var actualBool = list.Remove(elementToRemove);

            //arrange
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedCount, list.Count, message: "Remove method works incorrectly");
                Assert.AreEqual(expectedBool, actualBool, message: "Remove method works incorrectly");
            });

        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, 4, 4)]
        [TestCase(0, new int[] { 1, 2, 3, }, 2, 2)]
        [TestCase(0, new int[] { 1, 5 }, 1, 5)]
        public void RemoveAt_Position_ExpectedCountReturned(int position, int[] elements, int expectedCount, int excpectedResult)
        {
            //arrange
            CustomList<int> list = new CustomList<int>(elements);

            //act
            list.RemoveAt(position);
            var actualResult = list[position];

            //arrange
            Assert.Multiple(() =>
            {
                Assert.AreEqual(excpectedResult, actualResult, message: "RemoveAt works incorrectly");

                Assert.AreEqual(expectedCount, list.Count, message: "RemoveAt works incorrectly");
            });
        }


        [TestCase(0)]
        [TestCase(5)]
        [TestCase(2)]
        public void Insert_AtPositionValue_ReturnCount(int position)
        {
            //arrange
            CustomList<int> list = new CustomList<int>(1, 2, 7, 8, 10);

            //act
            int elementToInsert = 100;
            list.Insert(position, elementToInsert);
            int count = list.Count;

            int actualValue = list[position];


            //arrange
            Assert.Multiple(() =>
            {
                Assert.AreEqual(elementToInsert, actualValue, message: "Insert or Get Count  work incorrectly ");
                Assert.AreEqual(6, count, message: "Insert or Get Count  work incorrectly ");
            });
        }


        [Test]
        public void CopyTo_ReturnsArray()
        {
            //arrange
            CustomList<int> list = new CustomList<int>(1, 2, 3, 4, 5);
            int[] array = new int[10];

            //act
            list.CopyTo(array, 2);

            //assert
            Assert.AreEqual(array[2], 1, message: "CopyTo works incorrectly");
        }

        [TestCase(new int[] { 5, 2, 7, 10 })]
        [TestCase(new int[] { 3, 1 })]
        [TestCase(new int[] { 55, 30, 1, 19, 6, 6 })]
        public void Head_ReturnElementsOfCollection(int[] list)
        {
            //Arrange

            var exHead = list[0];

            CustomList<int> custom = new CustomList<int>(list);
            var actualHead = custom.Head;

            var current = actualHead;
            List<int> actualList = new List<int>();

            //Act
            while (current != null)
            {
                actualList.Add(current.Data);
                current = current.Next;
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(actualHead != null);

                Assert.AreEqual(exHead, actualHead.Data);


                CollectionAssert.AreEqual(list, actualList, message: "Head property works incorrect ");
            });
        }

        [TestCase(new int[] { 5, 2, 7, 10 })]
        [TestCase(new int[] { 9, 0 })]
        [TestCase(new int[] { 1, 1, 1, 1, 7, 5, 3 })]
        public void Head_AfterAddNewItem_ReturnSameCollection(int[] list)
        {
            //Arrange

            int addElement = 10;
            int? actualLast = null;
            CustomList<int> custom = new CustomList<int>(list);

            //Act
            var exHead = list[0];
            var actualHead = custom.Head;
            custom.Add(addElement);
            var current = actualHead;
            while (current != null)
            {
                actualLast = current.Data;
                current = current.Next;
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(actualHead != null);
                Assert.AreEqual(exHead, actualHead.Data);
                Assert.AreEqual(addElement, actualLast, message: "Head property works incorrect");

            });

        }

        [TestCase(new int[] { 5, 2, 7, 10 }, 5)]
        [TestCase(new int[] { 1, 1, 1 }, 1)]
        [TestCase(new int[] { -6, 0, 11, 55, -4 }, -4)]
        public void Head_AfterRemoveItem_ReturnSameCollection(int[] array, int removeElement)
        {
            //Arrange
            var list = array.ToList();
            var exHead = list[0];
            List<int> actualList = new List<int>();

            //Act
            CustomList<int> custom = new CustomList<int>(list);
            custom.Remove(removeElement);
            list.Remove(removeElement);

            var current = custom.Head;
            while (current != null)
            {
                actualList.Add(current.Data);
                current = current.Next;
            }
            //Assert
            CollectionAssert.AreEqual(list, actualList, message: "Head property works incorrect ");

        }
        #endregion



        //TODO: Uncomment this if you want to check your task for advanced unit tests
        //#region Advanced
        //[Test]
        //public void CopyTo_ArrayIsNull_ThrowsArgumentNullException()
        //{
        //    //arrange
        //    CustomList<int> list = new CustomList<int>(1, 2, 3, 4, 5);
        //    int[] array = null;
        //    var expectedEx = typeof(ArgumentNullException);
        //    //act
        //    var actEx = Assert.Catch(() => list.CopyTo(array, 2));
        //    //assert           
        //    Assert.AreEqual(expectedEx, actEx.GetType(),
        //        message: "Copy To throws ArgumentNullException ,if array is null ");

        //}

        //[Test]
        //public void CopyTo_ThrowsArgumentException()
        //{
        //    //arrange
        //    CustomList<int> list = new CustomList<int>(1, 2, 3, 4, 5);
        //    int[] array = new int[2];
        //    var expectedEx = typeof(ArgumentException);
        //    //act
        //    var actEx = Assert.Catch(() => list.CopyTo(array, 2));
        //    //assert            
        //    Assert.AreEqual(expectedEx, actEx.GetType(),
        //        message: "Copy to throws ArgumentException in case array has invalid size");

        //}
        //[Test]
        //public void GetEnumerator_OfListAndCustomList_ShouldHaveEqualElements()
        //{
        //    //arrange 
        //    List<int> list = new List<int>() { 1, 2, 3 };
        //    CustomList<int> custom = new CustomList<int>(list);
        //    //act
        //    var en = list.GetEnumerator();
        //    var en2 = custom.GetEnumerator();
        //    //assert
        //    if (en.MoveNext() && en2.MoveNext())
        //    {
        //        Assert.AreEqual(en.Current, en2.Current,
        //            message: "GetEnumerator works incorrectly");
        //    }
        //}

        //[Test]
        //public void GetEnumerator_UsingIEnumerableExplicitlyOfListAndCustomList_ShouldHaveEqualElements()
        //{
        //    //arrange 
        //    List<int> list = new List<int>() { 1, 2, 3 };
        //    CustomList<int> custom = new CustomList<int>(list);
        //    List<int> actualList = new List<int>();

        //    //act
        //    IEnumerable enumerable = custom;
        //    foreach (int item in enumerable)
        //    {
        //        actualList.Add(item);
        //    }

        //    //assert
        //    CollectionAssert.AreEqual(list, actualList, message: "GetEnumerator works incorrectly");
        //}
        //[Test]
        //public void CreateCustomList_WithNullList_ShouldThrowArgumentNullException()
        //{
        //    //arrange
        //    List<int> list = null;
        //    var expectedEx = typeof(ArgumentNullException);
        //    //act
        //    var actEx = Assert.Catch(() => new CustomList<int>(list));
        //    //assert
        //    Assert.AreEqual(expectedEx, actEx.GetType(),
        //        message: "CustomList can't be created  in case of list is null ");
        //}

        //[Test]
        //public void CreateCustomList_WithNullArray_ShouldThrowArgumentNullException()
        //{
        //    int[] array = null;
        //    var expectedEx = typeof(ArgumentNullException);
        //    var actualEx = Assert.Catch(() => new CustomList<int>(array));
        //    Assert.AreEqual(expectedEx, actualEx.GetType(), message: "Custom List can't be created in case of array is null");
        //}

        //[TestCase(-2)]
        //[TestCase(6)]
        //public void Insert_AtWrongPositionValue_ThrowArgumentOutOfRange(int position)
        //{
        //    //arrange
        //    CustomList<int> list = new CustomList<int>(1, 2, 3, 4, 5);
        //    var expectedEx = typeof(ArgumentOutOfRangeException);
        //    //act
        //    var actEx = Assert.Catch(() => list.Insert(position, 100));
        //    //assert
        //    Assert.AreEqual(expectedEx, actEx.GetType(),
        //        message: "Insert throws ArgumentOutOfRangeException, if position is out of list range ");

        //}

        //[Test]
        //public void Insert_AtPositionNullValue_ThrowsArgumentsNullException()
        //{
        //    //arrange
        //    CustomList<object> list = new CustomList<object>();
        //    var expectedEx = typeof(ArgumentNullException);
        //    //act
        //    var actEx = Assert.Catch(() => list.Insert(0, null));
        //    //assert           
        //    Assert.AreEqual(expectedEx, actEx.GetType(),
        //        message: "Insert throws ArgumentNullException in case  item is null");

        //}
        //[TestCase(-1)]
        //[TestCase(3)]
        //public void RemoveAt_WrongPosition_ThrowIndexOutOfRangeException(int position)
        //{
        //    //arrange
        //    CustomList<int> list = new CustomList<int>(1, 0);
        //    var expectedEx = typeof(ArgumentOutOfRangeException);
        //    //act
        //    var actEx = Assert.Catch(() => list.RemoveAt(position));
        //    Assert.AreEqual(expectedEx, actEx.GetType(),
        //        message: "RemoveAt throws ArgumentOutOfRangeException in case  position is out of list range  ");

        //}
        //[TestCase(-1)]
        //[TestCase(2)]
        //public void Get_WrongIndex_ThrowsIndexOutOfRange(int index)
        //{
        //    //arrange
        //    CustomList<int> list = new CustomList<int>(1);
        //    var expectedEx = typeof(IndexOutOfRangeException);
        //    //act
        //    var actEx = Assert.Catch(() => list[index].ToString());

        //    Assert.AreEqual(expectedEx, actEx.GetType(),
        //        message: "Indexer throws IndexOutOfRangeException in case index is out of list range  ");


        //}
        //[Test]
        //public void Remove_Null_ThrowArgumentNullException()
        //{
        //    //arrange
        //    CustomList<object> list = new CustomList<object>(1, 2, 3);
        //    var expectedEx = typeof(ArgumentNullException);
        //    //act
        //    var actEx = Assert.Catch(() => list.Remove(null));
        //    //assert           
        //    Assert.AreEqual(expectedEx, actEx.GetType(),
        //        message: "Remove throws ArgumentNullException in case  item is null ");

        //}
        //#endregion
    }
}
