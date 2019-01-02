using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Structs
{
    public class MyCircularQueue
    {
        private int[] _array;
        private int _head;
        private int _tail;
        private int _maxLen;
        /** Initialize your data structure here. Set the size of the queue to be k. */
        public MyCircularQueue(int k)
        {
            _array = new int[k];
            _head = -1;
            _tail = -1;
            _maxLen = k;
        }

        /** Insert an element into the circular queue. Return true if the operation is successful. */
        public bool EnQueue(int value)
        {
            if (IsFull())
                return false;

            if (_head == -1 && _tail == -1)
            {
                _head = 0;
                _tail = 0;
            }
            else if (_tail == _maxLen - 1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }
            _array[_tail] = value;
            return true;
        }

        /** Delete an element from the circular queue. Return true if the operation is successful. */
        public bool DeQueue()
        {
            if (IsEmpty())
                return false;
            _array[_head] = 0;

            if (_head == _tail)
            {
                _head = _tail = -1;
                return true;
            }

            if (_head == _maxLen - 1)
                _head = 0;
            else
                _head++;
            return true;
        }

        /** Get the front item from the queue. */
        public int Front()
        {
            if (IsEmpty())
                return -1;
            return _array[_head];
        }

        /** Get the last item from the queue. */
        public int Rear()
        {
            if (IsEmpty())
                return -1;
            return _array[_tail];
        }

        /** Checks whether the circular queue is empty or not. */
        public bool IsEmpty()
        {
            return _head == -1 && _tail == -1;
        }

        /** Checks whether the circular queue is full or not. */
        public bool IsFull()
        {
            if (_head == 0 && _tail == _maxLen - 1 || (_head > _tail && (_head - _tail) == 1))
                return true;
            else
                return false;
        }
    }
}
