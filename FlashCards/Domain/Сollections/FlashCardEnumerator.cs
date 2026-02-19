using System;
using System.Collections;
using FlashCards.Domain.Core;

namespace FlashCards.Domain.Collections
{
    public class FlashCardEnumerator : IEnumerator
    {
        private FlashCard[] items;
        private int count;
        private int position = -1;

        public FlashCardEnumerator(FlashCard[] items, int count)
        {
            this.items = items;
            this.count = count;
        }

        public object Current
        {
            get { return items[position]; }
        }

        public bool MoveNext()
        {
            position++;
            return position < count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
