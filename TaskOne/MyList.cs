using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TaskOne
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] _collection;

        public int Length { get; private set; }

        public MyList()
        {
            _collection = new T[16];
            Length = 0;
        }

        public MyList(int length)
        {
            _collection = new T[length];
            Length = length;
        }

        public T this[int index]
        {
            get
            {
                CheckRangeOfIndex(index);
                return _collection[index];
            }
            set
            {
                CheckRangeOfIndex(index);
                _collection[index] = value;
            }
        }

        public override string ToString()
        {
            return $"This is list which contains {Length} items";
        }

        #region Instance Methods

        //TODO optimize this function 
        public void Add(T item)
        {
            Length++;
            if (_collection.Length < Length)
            {
                ResizeUnderlyingArray();
            }
            _collection[Length - 1] = item;
        }

        //TODO optimize this function
        public void AddRange(IEnumerable<T> list)
        {
            foreach (T item in list)
            {
                Add(item);
            }
        }

        public void Remove()
        {
            _collection[Length - 1] = default;
            Length--;
        }

        public void RemoveItem(T item)
        {
            int lItemIndex = FindIndex(item);
            if (lItemIndex != -1)
                RemoveAtIndex(lItemIndex);
        }

        //TODO optimize this
        public void RemoveAtIndex(int index)
        {
            CheckRangeOfIndex(index);

            T[] lTempArray = _collection;
            Length--;
            for (int i = index; i < lTempArray.Length - 1; i++)
            {
                _collection[i] = lTempArray[i + 1];
            }
        }

        public int FindIndex(T item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_collection[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_collection[i].Equals(item))
                    return true;
            }
            return false;
        }

        //TODO use delegete here and inject function to check if condition
        public void SortByAscending()
        {
            bool lIsSorted = false;
            for (int y = 0; y < Length - 1 && !lIsSorted; y++)
            {
                lIsSorted = SortInnerLoop(IsGreater);
            }
        }

        //TODO same as above
        public void SortByDescending()
        {
            bool lIsSorted = false;
            for (int y = 0; y < Length && !lIsSorted; y++)
            {
                lIsSorted = SortInnerLoop(IsLesser);
            }
        }

        #endregion

        #region Private methods

        private void CheckRangeOfIndex(int index)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException();
        }

        private void ResizeUnderlyingArray()
        {
            T[] lTempArray = _collection;
            _collection = new T[lTempArray.Length * 2];
            for (int i = 0; i < lTempArray.Length; i++)
            {
                _collection[i] = lTempArray[i];
            }
        }

        #region Sort Helper Functions  

        private bool SortInnerLoop(Predicate<int> predicate)
        {
            bool lIsUnchnaged = true;
            for (int i = 0; i < Length - 1; i++)
            {
                CheckChangesInSortOrder(predicate, i, ref lIsUnchnaged);
            }
            return lIsUnchnaged;
        }

        private void CheckChangesInSortOrder(Predicate<int> predicate, int index, ref bool swapOccured)
        {
            if (CheckMatchingCondition(predicate, index))
            {
                Swap(index);
                swapOccured = false;
            }
        }

        private bool CheckMatchingCondition(Predicate<int> predicate, int index)
        {
            return predicate(CompareItems(index));
        }

        private int CompareItems(int index)
        {
            IComparer<T> comparer = Comparer<T>.Default;
            return comparer.Compare(_collection[index], _collection[index + 1]);
        }

        private void Swap(int index)
        {
            T lTempItem = _collection[index];
            _collection[index] = _collection[index + 1];
            _collection[index + 1] = lTempItem;
        }

        private Predicate<int> IsGreater = val => val > 0;
        private Predicate<int> IsLesser = val => val < 0;

        #endregion

        #endregion

        #region IEnumerable

        public IEnumerator<T> GetEnumerator() => new Enumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region Enumerator

        public class Enumerator : IEnumerator<T>
        {
            private MyList<T> _list;
            private int _totalItems;
            private int _counter;

            public Enumerator(MyList<T> list)
            {
                this._list = list;
                _totalItems = list.Length;
                _counter = -1;
            }

            public T Current => _list._collection[_counter];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                _counter++;
                return _counter < _totalItems;
            }

            public void Reset() => _counter = -1;
        }

        #endregion
    }
}