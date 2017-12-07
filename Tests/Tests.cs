using System;
using LinkedList;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private MyLinkedList<string> _linkedList;

        [SetUp]
        public void Init()
        {
            _linkedList = new MyLinkedList<string>();
        }

        [Test]
        public void ShouldReturnLength()
        {
            _linkedList.Add("test");
            Assert.True(_linkedList.Length().Equals(1));
        }

        [Test]
        public void ShouldAddElement()
        {
            _linkedList.Add("snow");
            Assert.True(_linkedList.Length().Equals(1));
        }

        [Test]
        public void ShouldAddElementByIndex()
        {
            _linkedList.AddAt(0, "tree");
            Assert.True((_linkedList.Length().Equals(1)));
        }

        [Test]
        public void ShouldAddSecondElementByIndex()
        {
            _linkedList.AddAt(0, "dog");
            _linkedList.AddAt(1, "cat");
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void ShouldAddSecondElementBySameIndex()
        {
            _linkedList.AddAt(0, "one");
            _linkedList.AddAt(0, "two");
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void ShouldRemoveElement()
        {
            _linkedList.Add("cat");
            _linkedList.Remove("cat");
            Assert.True(_linkedList.Length().Equals(0));
        }

        [Test]
        public void ShouldRemoveMidleElement()
        {
            _linkedList.Add("spring");
            _linkedList.Add("summer");
            _linkedList.Add("winter");
            _linkedList.Remove("summer");
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void ShouldRemoveLastElement()
        {
            _linkedList.Add("spring");
            _linkedList.Add("summer");
            _linkedList.Add("winter");
            _linkedList.Remove("winter");
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void ShouldRemoveFirstElement()
        {
            _linkedList.Add("spring");
            _linkedList.Add("summer");
            _linkedList.Add("winter");
            _linkedList.Remove("spring");
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void ShouldRemoveElementByIndex()
        {
            _linkedList.Add("element");
            _linkedList.RemoveAt(0);
            Assert.True(_linkedList.Length().Equals(0));
        }

        [Test]
        public void ShouldRemoveElementByFirstIndex()
        {
            _linkedList.Add("1");
            _linkedList.Add("2");
            _linkedList.Add("3");
            _linkedList.RemoveAt(0);
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void ShouldRemoveElementByMidleIndex()
        {
            _linkedList.Add("1");
            _linkedList.Add("2");
            _linkedList.Add("3");
            _linkedList.RemoveAt(1);
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void ShouldRemoveElementByLastIndex()
        {
            _linkedList.Add("1");
            _linkedList.Add("2");
            _linkedList.Add("3");
            _linkedList.RemoveAt(2);
            Assert.True(_linkedList.Length().Equals(2));
        }

        [Test]
        public void ShouldShowElementByIndex()
        {
            _linkedList.Add("Sun");
            var o = _linkedList.ElementAt(0);
            Assert.AreEqual(o, "Sun");
        }

        [Test]
        public void ShouldNotShowElementByNullIndex()
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
        public void ShouldShowElementByIndexAfterChangedValue()
        {
            _linkedList.Add("Black");
            _linkedList.Add("White");
            _linkedList.AddAt(1, "Red");
            var o = _linkedList.ElementAt(1);
            Assert.AreEqual(o, "Red");
        }

        [Test]
        public void ShouldWorkForeach()
        {
            _linkedList.Add("1");
            _linkedList.Add("2");
            _linkedList.Add("3");

            string res = " ";

            foreach (var element in _linkedList)
            {
                res += " " + element;
            }

            var trim = res.Trim();
            Assert.AreEqual(trim, "1 2 3");
        }
    }
}