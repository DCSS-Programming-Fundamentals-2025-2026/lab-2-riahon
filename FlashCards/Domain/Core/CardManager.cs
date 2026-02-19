using System;

namespace FlashCards.Domain.Core
{
    public class CardManager
    {
        public FlashCard[] FlashCards = new FlashCard[200];

        public void CreateCard(string question, string answer)
        {
            if (string.IsNullOrWhiteSpace(question) || string.IsNullOrWhiteSpace(answer))
                throw new ArgumentException("Питання та відповідь не можуть бути порожніми.");

            int idC = 0;
            int emptyIndex = -1;

            for (int i = 0; i < FlashCards.Length; i++)
            {
                if (FlashCards[i] != null)
                {
                    if (FlashCards[i].Id > idC)
                    {
                        idC = FlashCards[i].Id;
                    }
                }
                else if (emptyIndex == -1)
                {
                    emptyIndex = i; 
                }
            }

            if (emptyIndex == -1)
                throw new InvalidOperationException("Масив карток переповнений.");

            idC++;
            FlashCard card = new FlashCard(id: idC, question: question, answer: answer);
            FlashCards[emptyIndex] = card;
        }
        public void DeleteCard(int id)
        {
            for (int i = 0; i < FlashCards.Length; i++)
            {
                if (FlashCards[i] != null && FlashCards[i].Id == id)
                {
                    for (int j = i; j < FlashCards.Length - 1; j++)
                    {
                        FlashCards[j] = FlashCards[j + 1];
                    }
                    FlashCards[FlashCards.Length - 1] = null;
                    return;
                }
            }

            throw new ArgumentException($"Картку з ID {id} не знайдено.");
        }

        public void ChangeCard(int id, int choice, string newValue)
        {
            if (string.IsNullOrWhiteSpace(newValue))
                throw new ArgumentException("Нове значення не може бути порожнім.");

            for (int i = 0; i < FlashCards.Length; i++)
            {
                if (FlashCards[i] != null && FlashCards[i].Id == id)
                {
                    if (choice == 1)
                        FlashCards[i].Question = newValue;
                    else if (choice == 2)
                        FlashCards[i].Answer = newValue;
                    else
                        throw new ArgumentException("Невірний вибір поля для зміни.");

                    return;
                }
            }

            throw new ArgumentException($"Картку з ID {id} не знайдено.");
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