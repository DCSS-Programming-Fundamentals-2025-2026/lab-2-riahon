using System;

namespace FlashCards.Domain.Core
{
    public class FlashCard : CardBase, IComparable
    {
        public FlashCard(int id, string question, string answer) : base(id, question, answer)
        {
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (!(obj is FlashCard)) throw new ArgumentException("Об'єкт не є FlashCard.");
            FlashCard other = (FlashCard)obj;
            return Question.CompareTo(other.Question);
        }
    }
}