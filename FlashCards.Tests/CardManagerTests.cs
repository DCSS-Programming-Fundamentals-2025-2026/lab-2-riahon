using System;
using NUnit.Framework;
using FlashCards.Domain.Core;

namespace FlashCards.Tests
{
    [TestFixture]
    public class CardManagerTests
    {
        [Test]
        public void CreateCard_ValidInputs_AddsCardSuccessfully()
        {
            var manager = new CardManager();
            manager.CreateCard("Що таке C#?", "Мова");

            // Сучасний синтаксис Assert.That
            Assert.That(manager.FlashCards.Count, Is.EqualTo(1));
            Assert.That(manager.FlashCards.GetAt(0).Question, Is.EqualTo("Що таке C#?"));
        }

        [TestCase("", "Відповідь")]
        [TestCase("Питання", "  ")]
        [TestCase(null, "Відповідь")]
        public void CreateCard_InvalidInputs_ThrowsArgumentException(string question, string answer)
        {
            var manager = new CardManager();

            // Перевірка на помилку через Assert.That
            Assert.That(() => manager.CreateCard(question, answer), Throws.ArgumentException);
            Assert.That(manager.FlashCards.Count, Is.EqualTo(0));
        }

        [Test]
        public void DeleteCard_ValidId_RemovesCardAndShiftsCollection()
        {
            var manager = new CardManager();
            manager.FlashCards.Add(new FlashCard(1, "Питання 1", "Відповідь 1"));
            manager.FlashCards.Add(new FlashCard(2, "Питання 2", "Відповідь 2"));
            manager.FlashCards.Add(new FlashCard(3, "Питання 3", "Відповідь 3"));

            manager.DeleteCard(2);

            Assert.That(manager.FlashCards.Count, Is.EqualTo(2));
            Assert.That(manager.FlashCards.GetAt(1).Id, Is.EqualTo(3));
        }

        [Test]
        public void DeleteCard_InvalidId_ThrowsArgumentException()
        {
            var manager = new CardManager();
            manager.FlashCards.Add(new FlashCard(1, "П", "В"));

            Assert.That(() => manager.DeleteCard(99), Throws.ArgumentException);
        }

        [Test]
        public void ChangeCard_ValidData_UpdatesCardContent()
        {
            var manager = new CardManager();
            manager.FlashCards.Add(new FlashCard(1, "Старе питання", "Стара відповідь"));

            manager.ChangeCard(1, 1, "Нове питання");

            Assert.That(manager.FlashCards.GetAt(0).Question, Is.EqualTo("Нове питання"));
        }

        [Test]
        public void FindById_ExistingId_ReturnsCorrectCard()
        {
            var manager = new CardManager();
            manager.FlashCards.Add(new FlashCard(5, "П", "В"));
            manager.FlashCards.Add(new FlashCard(10, "П2", "В2"));

            var result = manager.FindById(10);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(10));
        }
    }
}