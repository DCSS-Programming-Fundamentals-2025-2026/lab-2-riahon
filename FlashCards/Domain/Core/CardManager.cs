using System;
namespace FlashCards.Domain.Core
{
    public class CardManager
    {
        public FlashCard[] FlashCards = new FlashCard[200];

        public void CreateCard()
        {
            int idC = 0;
            for (int i = 0; i < 200; i++)
            {
                if (FlashCards[i] != null)
                {
                    if (FlashCards[i].Id > idC)
                    {
                        idC = FlashCards[i].Id;
                    }
                }
            }
            idC++;
            Console.WriteLine("Введіть питання для картки: ");
            string inputQ = Console.ReadLine();
            Console.WriteLine("Введіть правильний варіант відповіді:");
            string inputA = Console.ReadLine();
            
            FlashCard Card = new FlashCard(id:idC, question:inputQ, answer:inputA);
            FlashCards[idC] = Card;
        }

        public void DeleteCard()
        {
            Console.WriteLine("Введіть id картки, яку хочете видалити:");
            int idC = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < FlashCards.Length; i++)
            {
                if (FlashCards[i] != null && FlashCards[i].Id == idC)
                {
                    FlashCards[i] = null;
                    Console.WriteLine("Картку видалено.");
                    return;
                }
            }

            Console.WriteLine("Картку не знайдено.");
        }

        public void ChangeCard()
        {
            Console.WriteLine("Введіть id картки, яку хочете змінити:");
            int idC = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < FlashCards.Length; i++)
            {
                if (FlashCards[i] != null && FlashCards[i].Id == idC)
                {
                    Console.WriteLine("Що ви хочете змінити?");
                    Console.WriteLine("1. Question");
                    Console.WriteLine("2. Answer");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.WriteLine("Введіть нове питання:");
                        FlashCards[i].Question = Console.ReadLine();
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Введіть нову відповідь:");
                        FlashCards[i].Answer = Console.ReadLine();
                    }

                    Console.WriteLine("Картку змінено.");
                    return;
                }
            }

            Console.WriteLine("Картку не знайдено.");
        }

        public FlashCard FindById(int id)
        {
            FlashCard[] validCards = new FlashCard[200];
            int count = 0;

            for (int i = 0; i < FlashCards.Length; i++)
            {
                if (FlashCards[i] != null)
                {
                    validCards[count] = FlashCards[i];
                    count++;
                }
            }

            int left = 0;
            int right = count - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (validCards[middle].Id == id)
                    return validCards[middle];

                if (validCards[middle].Id < id)
                    left = middle + 1;
                else
                    right = middle - 1;
            }

            return null;
        }

    }
}