using FlashCards.Domain.Core;
using FlashCards.Domain.Interfaces;

namespace FlashCards.App
{
    public class AppState
    {
        public CardManager CardManager { get; }
        public IQuiz CurrentQuiz { get; set; }

        public AppState()
        {
            CardManager = new CardManager();
        }
    }
}