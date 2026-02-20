using System.Collections;
using FlashCards.Domain.Core;

namespace FlashCards.Domain.Comparers
{
    public class FlashCardIdComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            FlashCard a = x as FlashCard;
            FlashCard b = y as FlashCard;

            return a.Id.CompareTo(b.Id);
        }
    }
}
