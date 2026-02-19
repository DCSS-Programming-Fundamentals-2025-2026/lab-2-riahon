using System;
using FlashCards.Domain.Core;

namespace FlashCards.App
{
    public class DemoRunner
    {
        private CardManager _manager = new CardManager();

        public void CreateCard()
        {
            Console.WriteLine("Введіть питання для картки: ");
            string inputQ = Console.ReadLine();
            Console.WriteLine("Введіть правильний варіант відповіді:");
            string inputA = Console.ReadLine();

            try
            {
                _manager.CreateCard(inputQ, inputA);
                Console.WriteLine("Картку успішно створено.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        public void DeleteCard()
        {
            Console.WriteLine("Введіть id картки, яку хочете видалити:");
            if (int.TryParse(Console.ReadLine(), out int idC))
            {
                try
                {
                    _manager.DeleteCard(idC);
                    Console.WriteLine("Картку видалено.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Некоректний ID.");
            }
        }

        public void ChangeCard()
        {
            Console.WriteLine("Введіть id картки, яку хочете змінити:");
            if (!int.TryParse(Console.ReadLine(), out int idC))
            {
                Console.WriteLine("Некоректний ID.");
                return;
            }

            Console.WriteLine("Що ви хочете змінити?");
            Console.WriteLine("1. Question");
            Console.WriteLine("2. Answer");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Некоректний вибір.");
                return;
            }

            Console.WriteLine("Введіть нове значення:");
            string newValue = Console.ReadLine();

            try
            {
                _manager.ChangeCard(idC, choice, newValue);
                Console.WriteLine("Картку змінено.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
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
            if (int.TryParse(Console.ReadLine(), out int id))
            {
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
            else
            {
                Console.WriteLine("Некоректний ID.");
            }
        }
    }
}