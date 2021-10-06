using System;
using System.Collections;
using System.Collections.Generic;

namespace ModuleHW
{
    public class ArrayList<T> : IEnumerable, IEnumerable<T>, IReadOnlyList<T>
    {
        private int _counter;
        private int _initSize;
        private int _position;
        private T[] _arrayList;

        public ArrayList()
        {
            _counter = 0;
            _initSize = 5;
            _position = -1;
            _arrayList = new T[_initSize];
        }

        public ArrayList(int initSize)
        {
            if (initSize > 0)
            {
                _counter = 0;
                _initSize = initSize;
                _position = -1;
                _arrayList = new T[_initSize];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Array length couldn't be less than 1!");
            }
        }

        public int Capacity => _arrayList.Length;
        public int Count => _counter;

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _counter)
                {
                    return _arrayList[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }
            }
            set
            {
                if (index >= 0 && index < _counter)
                {
                    _arrayList[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }
            }
        }

        public bool Add(T item)
        {
            if (item == null)
            {
                return false;
            }

            CheckCapacity(_counter);
            _arrayList[_counter++] = item;

            return true;
        }

        public bool AddRange(T[] items)
        {
            if (items == null)
            {
                return false;
            }

            CheckCapacity(_counter + items.Length);

            for (int i = 0; i < items.Length; i++)
            {
                _arrayList[_counter++] = items[i];
            }

            return true;
        }

        public bool AddItems(params T[] items)
        {
            if (items == null)
            {
                return false;
            }

            CheckCapacity(_counter + items.Length);

            for (int i = 0; i < items.Length; i++)
            {
                _arrayList[_counter++] = items[i];
            }

            return true;
        }

        public bool Insert(int index, T item)
        {
            if (item == null || index > _counter)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine($"{GetType().Name[0..^2]}<{typeof(T).Name}>.Insert: ");
                Console.WriteLine(item == null ? "Item is null!" : "Index out of range!");
                return false;
            }

            CheckCapacity(_counter);

            for (int i = _counter++; i > index; i--)
            {
                _arrayList[i] = _arrayList[i - 1];
            }

            _arrayList[index] = item;

            return true;
        }

        public bool InsertRange(int startindex, params T[] items)
        {
            if (items == null || startindex > _counter)
            {
                Console.WriteLine(string.Empty);
                Console.Write($"{GetType().Name[0..^2]}<{typeof(T).Name}>.InsertRange: ");
                Console.WriteLine(items == null ? "Items is null!" : "Start index out of range!");
                return false;
            }

            CheckCapacity(_counter + items.Length);

            for (int i = _counter + items.Length - 1; i > startindex + items.Length - 1; i--)
            {
                _arrayList[i] = _arrayList[i - items.Length];
            }

            for (int i = 0; i < items.Length; i++)
            {
                _arrayList[startindex + i] = items[i];
                _counter++;
            }

            return true;
        }

        public bool Remove(T item)
        {
            if (item == null)
            {
                return false;
            }

            var isSuccess = false;

            for (int i = 0; i < _counter; i++)
            {
                if (_arrayList[i].Equals(item))
                {
                    isSuccess = true;

                    for (int j = i; j < _counter - 1; j++)
                    {
                        _arrayList[j] = _arrayList[j + 1];
                    }

                    _arrayList[--_counter] = default(T);
                    CheckCapacity();
                }
            }

            if (!isSuccess)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine($"{GetType().Name[0..^2]}<{typeof(T).Name}>.Remove: There is no item with value \"{item}\"");
            }

            return isSuccess;
        }

        public bool RemoveRange(params T[] items)
        {
            if (items == null)
            {
                return false;
            }

            var isSuccess = false;

            foreach (var item in items)
            {
                var thisSuccess = false;

                for (int i = 0; i < _counter; i++)
                {
                    if (_arrayList[i].Equals(item))
                    {
                        isSuccess = true;
                        thisSuccess = true;

                        for (int j = i; j < _counter - 1; j++)
                        {
                            _arrayList[j] = _arrayList[j + 1];
                        }

                        _arrayList[--_counter] = default(T);
                        CheckCapacity();

                        i--;
                    }
                }

                if (!thisSuccess)
                {
                    Console.WriteLine(string.Empty);
                    Console.WriteLine($"{GetType().Name[0..^2]}<{typeof(T).Name}>.RemoveRange: There is no item with value \"{item}\"");
                }
            }

            return isSuccess;
        }

        public bool RemoveAt(int index)
        {
            var isSuccess = false;

            if (index >= 0 && index < _counter)
            {
                isSuccess = true;

                for (int i = index; i < _counter - 1; i++)
                {
                    _arrayList[i] = _arrayList[i + 1];
                }

                _arrayList[--_counter] = default(T);
                CheckCapacity();
            }

            if (!isSuccess)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine($"{GetType().Name[0..^2]}<{typeof(T).Name}>.RemoveAt: There is no item with index \"{index}\"");
            }

            return isSuccess;
        }

        public bool RemoveAtRange(params int[] indexes)
        {
            var isSuccess = false;
            var iteration = 0;

            foreach (var index in indexes)
            {
                if (index - iteration >= 0 && index - iteration < _counter)
                {
                    isSuccess = true;

                    for (int i = index - iteration++; i < _counter - 1; i++)
                    {
                        _arrayList[i] = _arrayList[i + 1];
                    }

                    _arrayList[--_counter] = default(T);
                    CheckCapacity();
                }
                else
                {
                    Console.WriteLine(string.Empty);
                    Console.WriteLine($"{GetType().Name[0..^2]}<{typeof(T).Name}>.RemoveAtRange: There is no item with index \"{index}\"");
                }
            }

            return isSuccess;
        }

        public void Sort()
        {
            Array.Sort(_arrayList, 0, _counter);
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(_arrayList, 0, _counter, comparer);
        }

        public void Reset()
        {
            _position = -1;
        }

        /*
        public IEnumerator<T> GetEnumeratorGeneric()
        {
            for (int i = 0; i < _arrayList.Length; i++)
            {
                yield return _arrayList[i];
            }
        }

        public IEnumerator GetEnumeratorNonGeneric()
        {
            for (int i = 0; i < _arrayList.Length; i++)
            {
                yield return _arrayList[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _arrayList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        */

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            while (true)
            {
                if (_position < _counter - 1)
                {
                    yield return _arrayList[++_position];
                }
                else
                {
                    Reset();
                    yield break;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<T>).GetEnumerator();
        }

        private void CheckCapacity(int count)
        {
            while (count >= _arrayList.Length)
            {
                Array.Resize(ref _arrayList, _arrayList.Length * 2);
            }
        }

        private void CheckCapacity()
        {
            while (_counter < _arrayList.Length / 2)
            {
                Array.Resize(ref _arrayList, _arrayList.Length / 2);
            }
        }
    }
}
