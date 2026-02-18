using System;
namespace FlashCards.Domain.Interfaces
{
    public interface IQuiz
    {
        void Start(int questionCount);
        int Score { get; }
        int[] WrongIndexes { get; }
    }

}