using System;
using Epam.Mentoring.Collections;
using NUnit.Framework;

namespace Epam.Mentoring.Collections.Tests
{
    [TestFixture]
    public class Tests
    {
        private LinkedList<string> _linkedList;

        [SetUp]
        public void Init()
        {
            _linkedList = new LinkedList<string>();
        }

        [Test]
        public void Length_AddElementInLinkedList_LengthEqualsNumberOfElements()
        {
            _linkedList.Add("test");
            Assert.True(_linkedList.Length().Equals(1));
        }

        [Test]
        public void Add_AddElement_LengthIsChanged()
        {
            _linkedList.Add("snow");
            Assert.True(_linkedList.Length().Equals(1));
        }

        [Test]
        public void AddAt_AddOneElementByIndex_LengthEqualsOne()
        {
            _linkedList.AddAt(0, "tree");
            Assert.True((_linkedList.Length().Equals(1)));
        }

        [Test]
        public void AddAt_AddTwoElementsByDeferentIndexes_LengthEqualsTwo()
        {
            _linkedList.AddAt(0, "dog");
            _linkedList.AddAt(1, "cat");
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void AddAt_AddTwoElementsBySameIndex_LengthEqualsTwo()
        {
            _linkedList.AddAt(0, "one");
            _linkedList.AddAt(0, "two");
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void Remove_RemoveElementByValue_LengthDecreasedByOne()
        {
            _linkedList.Add("cat");
            _linkedList.Remove("cat");
            Assert.True(_linkedList.Length().Equals(0));
        }

        [Test]
        public void Remove_RemoveMiddleElementByValue_LengthDecreasedByOne()
        {
            _linkedList.Add("spring");
            _linkedList.Add("summer");
            _linkedList.Add("winter");
            _linkedList.Remove("summer");
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void Remove_RemoveLastElementByValue_LengthDecreasedByOne()
        {
            _linkedList.Add("spring");
            _linkedList.Add("summer");
            _linkedList.Add("winter");
            _linkedList.Remove("winter");
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void Remove_RemoveFirstElementByValue_LengthDecreasedByOne()
        {
            _linkedList.Add("spring");
            _linkedList.Add("summer");
            _linkedList.Add("winter");
            _linkedList.Remove("spring");
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void RemoveAt_RemoveElementByIndex_LengthDecreasedByOne()
        {
            _linkedList.Add("element");
            _linkedList.RemoveAt(0);
            Assert.True(_linkedList.Length().Equals(0));
        }

        [Test]
        public void RemoveAt_RemoveElementByFirstIndex_LengthDecreasedByOne()
        {
            _linkedList.Add("1");
            _linkedList.Add("2");
            _linkedList.Add("3");
            _linkedList.RemoveAt(0);
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void RemoveAt_RemoveElementByMiddleIndex_LengthDecreasedByOne()
        {
            _linkedList.Add("1");
            _linkedList.Add("2");
            _linkedList.Add("3");
            _linkedList.RemoveAt(1);
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void RemoveAt_RemoveElementByLastIndex_LengthDecreasedByOne()
        {
            _linkedList.Add("1");
            _linkedList.Add("2");
            _linkedList.Add("3");
            _linkedList.RemoveAt(2);
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void ElementAt_GetValueByIndex_ValueEqualsValueByIndex()
        {
            _linkedList.Add("Sun");
            var o = _linkedList.ElementAt(0);
            Assert.AreEqual(o, "Sun");
        }

        [Test]
        public void ElementAt_GetValueByEmptyIndex_ThrowException()
        {
            Exception exception = null;
            _linkedList.Add("Live");
            _linkedList.Remove("Live");

            try
            {
                var o = _linkedList.ElementAt(0);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            if (exception != null) Assert.AreEqual(exception.Message, "There are not elements by this index");
        }

        [Test]
        public void ElementAt_GetValueWhichWasAddedInNonEmptyIndex_ValueEqualsValueByIndex()
        {
            _linkedList.Add("Black");
            _linkedList.Add("White");
            _linkedList.AddAt(1, "Red");
            var o = _linkedList.ElementAt(1);
            Assert.AreEqual(o, "Red");
        }

        [Test]
        public void Enumerator_UseForeach_AllElementsAreDisplyed()
        {
            _linkedList.Add("1");
            _linkedList.Add("2");
            _linkedList.Add("3");

            string res = " ";

            foreach (var element in _linkedList)
            {
                res += " " + element;
            }

            var result = res.Trim();
            Assert.AreEqual(result, "1 2 3");
        }
    }
}