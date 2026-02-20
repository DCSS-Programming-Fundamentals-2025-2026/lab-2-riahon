using System;
using FlashCards.Domain.Collections;

namespace FlashCards.Domain.Core
{
    public class CardManager
    {
        public FlashCardCollection FlashCards = new FlashCardCollection(200);

        public void CreateCard(string question, string answer)
        {
            if (string.IsNullOrWhiteSpace(question) || string.IsNullOrWhiteSpace(answer))
                throw new ArgumentException("Питання та відповідь не можуть бути порожніми.");

            int newId = 1;
            for (int i = 0; i < FlashCards.Count; i++)
            {
                if (FlashCards.GetAt(i).Id >= newId)
                    newId = FlashCards.GetAt(i).Id + 1;
            }

            FlashCard card = new FlashCard(newId, question, answer);
            FlashCards.Add(card);
        }

        public void DeleteCard(int id)
        {
            for (int i = 0; i < FlashCards.Count; i++)
            {
                if (FlashCards.GetAt(i).Id == id)
                {
                    FlashCards.RemoveAt(i);
                    return;
                }
            }
            throw new ArgumentException($"Картку з ID {id} не знайдено.");
        }

        public void ChangeCard(int id, int choice, string newValue)
        {
            if (string.IsNullOrWhiteSpace(newValue))
                throw new ArgumentException("Нове значення не може бути порожнім.");

            for (int i = 0; i < FlashCards.Count; i++)
            {
                if (FlashCards.GetAt(i).Id == id)
                {
                    if (choice == 1)
                        FlashCards.GetAt(i).Question = newValue;
                    else if (choice == 2)
                        FlashCards.GetAt(i).Answer = newValue;
                    else
                        throw new ArgumentException("Невірний вибір поля для зміни.");

                    return;
                }
            }
            throw new ArgumentException($"Картку з ID {id} не знайдено.");
        }

        public FlashCard FindById(int id)
        {
            for (int i = 0; i < FlashCards.Count; i++)
            {
                if (FlashCards.GetAt(i).Id == id)
                    return FlashCards.GetAt(i);
            }
            return null;
        }
    }
}