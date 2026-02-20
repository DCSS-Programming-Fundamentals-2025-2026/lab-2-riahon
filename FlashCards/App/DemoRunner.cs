using System;
using FlashCards.Domain.Core;
using FlashCards.Domain.Comparers;

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

            if (_manager.FlashCards.Count == 0)
            {
                Console.WriteLine("Список порожній.");
                return;
            }

            var it = _manager.FlashCards.GetEnumerator();
            while (it.MoveNext())
            {
                FlashCard card = (FlashCard)it.Current;
                Console.WriteLine($"ID: {card.Id} | Питання: {card.Question} | Відповідь: {card.Answer}");
            }
        }

        public void RunQuiz()
        {
            Console.Clear();
            Console.WriteLine("ТЕСТУВАННЯ");

            Test test = new Test(_manager.FlashCards.ToArray());

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

        public void ShowStats()
        {
            Console.WriteLine($"Кількість карток: {_manager.FlashCards.Count}");
        }

        public void SortCards()
        {
            FlashCard[] cards = _manager.FlashCards.ToArray();
            Console.WriteLine("Оберіть сортування:");
            Console.WriteLine("1. За питанням (A-Z)");
            Console.WriteLine("2. За ID");
            string choice = Console.ReadLine();

            if (choice == "1")
                Array.Sort(cards);
            else if (choice == "2")
                Array.Sort(cards, new FlashCardIdComparer());
            else
            {
                Console.WriteLine("Невірний вибір.");
                return;
            }

            Console.WriteLine("\nВідсортований список:");
            foreach (var card in cards)
            {
                if (card != null)
                    Console.WriteLine($"ID: {card.Id} | Питання: {card.Question} | Відповідь: {card.Answer}");
            }
        }
    }
}