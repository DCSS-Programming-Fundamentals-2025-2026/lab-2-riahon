using System;

namespace FlashCards.App
{
    public class Menu
    {
        private DemoRunner _runner = new DemoRunner();


        public void Run()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== FLASHCARDS MENU ===");
                Console.WriteLine("1. Створити картку");
                Console.WriteLine("2. Показати всі картки");
                Console.WriteLine("3. Редагувати картку");
                Console.WriteLine("4. Видалити картку");
                Console.WriteLine("5. Почати тестування");
                Console.WriteLine("6. Знайти картку за id");
                Console.WriteLine("7. Статистика");
                Console.WriteLine("8. Сортувати картки");
                Console.WriteLine("0. Вихід");
                Console.Write("\nВаш вибір: ");

                try
                {
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            _runner.CreateCard();
                            Pause();
                            break;
                        case "2":
                            _runner.ShowAllCards();
                            Pause();
                            break;
                        case "3":
                            _runner.ChangeCard();
                            Pause();
                            break;
                        case "4":
                            _runner.DeleteCard();
                            Pause();
                            break;
                        case "5":
                            _runner.RunQuiz();
                            Pause();
                            break;
                        case "6":
                            _runner.FindById();
                            Pause();
                            break;
                        case "7":
                            _runner.ShowStats();
                            Pause();
                            break;
                        case "8":
                            _runner.SortCards();
                            Pause();
                            break;
                        case "0":
                            isRunning = false;
                            Console.WriteLine("Дякуємо за використання!");
                            break;
                        default:
                            Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                            Pause();
                            break;
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void Pause()
        {
            Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
            Console.ReadLine();
        }
    }
}