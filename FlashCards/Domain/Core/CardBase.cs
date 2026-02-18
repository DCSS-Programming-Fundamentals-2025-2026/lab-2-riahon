using System;
namespace FlashCards.Domain.Core
{
    public abstract class CardBase
    {
        public int Id {get; set;}
        public string Question {get; set;}
        public string Answer {get; set;}

        public CardBase (int id, string question, string answer)
        {
            Id = id;
            Question = question;
            Answer = answer;
        }
    }
}