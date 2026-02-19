using System;
using System.Collections;
using FlashCards.Domain.Core;

namespace FlashCards.Domain.Collections
{
    public class FlashCardCollection : IEnumerable
    {
        private FlashCard[] _cards;
        private int _count;

        public FlashCardCollection(int capacity)
        {
            _cards = new FlashCard[capacity];
            _count = 0;
        }

        public int Count => _count;

        public void Add(FlashCard card)
        {
            if (_count < _cards.Length)
            {
                _cards[_count] = card;
                _count++;
            }
            else
            {
                throw new InvalidOperationException("Колекція заповнена");
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            for (int i = index; i < _count - 1; i++)
            {
                _cards[i] = _cards[i + 1];
            }

            _cards[_count - 1] = null;
            _count--;
        }

        public FlashCard GetAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            return _cards[index];
        }

        public void SetAt(int index, FlashCard card)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            _cards[index] = card;
        }

        public IEnumerator GetEnumerator()
        {
            return new FlashCardEnumerator(_cards, _count);
        }

        public FlashCard[] ToArray()
        {
            FlashCard[] arr = new FlashCard[_count];
            int index = 0;
            for (int i = 0; i < _count; i++)
            {
                if (_cards[i] != null)
                {
                    arr[index] = _cards[i];
                    index++;
                }
            }
            return arr;
        }
    }
}


