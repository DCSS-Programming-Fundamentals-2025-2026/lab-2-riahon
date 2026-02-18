using System;
namespace FlashCards.Domain.Core
{
    public class FlashCard : CardBase
    {
        public FlashCard(int id, string question, string answer) : base(id, question, answer)
        {
            
        }
    }
}