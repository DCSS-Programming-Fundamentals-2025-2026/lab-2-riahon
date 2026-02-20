using System;
using FlashCards.Domain.Interfaces;

namespace FlashCards.Domain.Core
{
    
    public class Test : IQuiz
    {
        private FlashCard[] _cards;
        private int _cardCount;

        public int Score { get; private set; }
        public int[] WrongIndexes { get; private set; }

        public Test(FlashCard[] cards)
        {
            _cards = cards;
            _cardCount = CountCards(cards);
            WrongIndexes = new int[200];
        }
        
        private int CountCards(FlashCard[] cards)
        {
            int count = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] != null)
                    count++;
            }
            return count;
        }

        private string[] RandomAndShuffleAnswers(FlashCard correctCard, FlashCard[] validCards)
        {
            int optionCount;

            if (validCards.Length >= 4)
                optionCount = 4;
            else
                optionCount = validCards.Length;

            string[] options = new string[optionCount];

            options[0] = correctCard.Answer;

            int filled = 1;
            int index = 0;

            while (filled < optionCount)
            {
                if (validCards[index] != correctCard)
                {
                    options[filled] = validCards[index].Answer;
                    filled++;
                }

                index++;
            }

            // просте перемішування (зсув)
            for (int i = 0; i < optionCount; i++)
            {
                int swap = (i + 1) % optionCount;

                string temp = options[i];
                options[i] = options[swap];
                options[swap] = temp;
            }

            return options;
        }


        public void Start(int questionCount)
        {
            Score = 0;
            int wrongCounter = 0;

            FlashCard[] validCards = new FlashCard[_cardCount];
            int index = 0;

            for (int i = 0; i < _cards.Length; i++)
            {
                if (_cards[i] != null)
                {
                    validCards[index] = _cards[i];
                    index++;
                }
            }

            if (_cardCount == 0)
            {
                Console.WriteLine("Немає карток для тесту.");
                return;
            }

            if (questionCount > _cardCount)
                questionCount = _cardCount;

            for (int q = 0; q < questionCount; q++)
            {
                FlashCard card = validCards[q];

                Console.WriteLine("\nПитання:");
                Console.WriteLine(card.Question);

                string[] options = RandomAndShuffleAnswers(card, validCards);

                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {options[i]}");
                }

                Console.Write("Ваша відповідь: ");
                int choice = Convert.ToInt32(Console.ReadLine()) - 1;

                if (choice >= 0 &&
                    choice < options.Length &&
                    options[choice] == card.Answer)
                {
                    Score++;
                }
                else
                {
                    WrongIndexes[wrongCounter] = q;
                    wrongCounter++;
                }
            }
        }
    }
}