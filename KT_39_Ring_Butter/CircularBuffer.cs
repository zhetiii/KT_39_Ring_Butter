using System;
using System.Collections;
using System.Collections.Generic;

namespace KT_39
{
    public class CircularBuffer<T> : IEnumerable<T>
    {
        private readonly T[] _buffer;
        private int _head = 0;
        private int _tail = 0;
        private int _size = 0;

        public int Capacity { get; }
        public int Count => _size;

        public CircularBuffer(int capacity)
        {
            Capacity = capacity;
            _buffer = new T[capacity];
        }

        public void Add(T item)
        {
            _buffer[_head] = item;
            _head = (_head + 1) %Capacity;

            if (_size < Capacity)
            {
                _size++;
            }
            else
            {
                _tail = (_tail + 1) % Capacity;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                int index = (_tail + i) % Capacity;
                yield return _buffer[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> Reverse()
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                int index = (_tail + i) % Capacity;
                yield return _buffer[index];
            }
        }
    }
}