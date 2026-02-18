using System;
using FlashCards.Domain.Core; 

namespace FlashCards.App
{
    public class DemoRunner
    {
        private CardManager _manager = new CardManager();

        public void CreateCard()
        {
            _manager.CreateCard();
        }

        public void DeleteCard()
        {
            _manager.DeleteCard();
        }

        public void ChangeCard()
        {
            _manager.ChangeCard();
        }

        public void ShowAllCards()
        {
            Console.WriteLine("\nСписок карток");
            bool isEmpty = true;

            foreach (var card in _manager.FlashCards)
            {
                if (card != null)
                {
                    Console.WriteLine($"ID: {card.Id} | Питання: {card.Question} | Відповідь: {card.Answer}");
                    isEmpty = false;
                }
            }

            if (isEmpty)
            {
                Console.WriteLine("Список порожній.");
            }
        }

        public void RunQuiz()
        {
            Console.Clear();
            Console.WriteLine("ТЕСТУВАННЯ");

            Test test = new Test(_manager.FlashCards);

            Console.Write("Скільки питань ви хочете? ");
            if (int.TryParse(Console.ReadLine(), out int count))
            {
                test.Start(count);

                Console.WriteLine($"\nВаш результат: {test.Score}");
            }
            else
            {
                Console.WriteLine("Некоректне число.");
            }
        }

        public void FindById()
        {
            Console.Write("Введіть ID картки: ");
            int id = Convert.ToInt32(Console.ReadLine());

            FlashCard card = _manager.FindById(id);

            if (card != null)
            {
                Console.WriteLine($"ID: {card.Id}");
                Console.WriteLine($"Питання: {card.Question}");
                Console.WriteLine($"Відповідь: {card.Answer}");
            }
            else
            {
                Console.WriteLine("Картку з таким ID не знайдено.");
            }
        }
    }
}