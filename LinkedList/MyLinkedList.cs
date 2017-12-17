using System;
using System.Collections;
using System.Collections.Generic;

namespace Epam.Mentoring.Collections
{
    public class LinkedList<E> : IEnumerable<E>
    {
        private int _size;
        private Entry<E> _first;
        private Entry<E> _last;

        private class Entry<E>
        {
            public readonly E Element;
            public Entry<E> Next;
            public Entry<E> Prev;

            public Entry(E element, Entry<E> next, Entry<E> prev)
            {
                Element = element;
                Next = next;
                Prev = prev;
            }
        }

        public int Length()
        {
            return _size;
        }

        public void Add(E value)
        {
            Entry<E> entry = new Entry<E>(value, null, _last);

            if (_last != null)
            {
                _last.Next = entry;
            }

            _last = entry;

            if (_first == null)
            {
                _first = entry;
            }
            _size++;
        }

        public void AddAt(int index, E value)
        {
            Entry<E> temp = GetEntryAt(index);

            if (temp == null)
            {
                Add(value);
                return;
            }

            Entry<E> post = temp.Next;
            Entry<E> pre = temp.Prev;
            Entry<E> newEntry = new Entry<E>(value, post, temp);

            if (pre != null)
            {
                pre.Next = newEntry;
            }

            if (post != null)
            {
                post.Prev = newEntry;
            }
            _size++;
        }

        public void Remove(E value)
        {
            E pointer = default(E);
            Entry<E> temp = _first;
            while (pointer != null && !pointer.Equals(value))
            {
                temp = temp.Next;
                pointer = temp.Element;
            }
            Entry<E> prev = temp.Prev;
            Entry<E> next = temp.Next;

            if (prev != null)
            {
                prev.Next = next;
            }
            _size--;
        }

        public void RemoveAt(int index)
        {
            Entry<E> temp = GetEntryAt(index);
            Entry<E> prev = temp.Prev;
            Entry<E> next = temp.Next;

            if (prev != null)
            {
                prev.Next = next;
            }

            if (next != null)
            {
                next.Prev = prev;
            }
            _size--;
        }

        public E ElementAt(int index)
        {
            Entry<E> temp = GetEntryAt(index);
            if (temp == null)
            {
                throw new Exception("There are not elements by this index");
            }
            return temp.Element;
        }

        private Entry<E> GetEntryAt(int index)
        {
            int pointer = 0;
            Entry<E> temp = _first;
            while (pointer != index)
            {
                temp = temp.Next;
                pointer++;
            }
            return temp;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

        IEnumerator<E> IEnumerable<E>.GetEnumerator()
        {
            Entry<E> current = _first;
            while (current != null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }
    }
}