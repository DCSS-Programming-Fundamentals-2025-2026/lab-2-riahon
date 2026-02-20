using System;
using Xunit;
using FlashCards.Domain.Core;

namespace FlashCards.Tests
{
    public class CardManagerTests
    {
        [Fact]
        public void CreateCard_ValidInputs_AddsCardSuccessfully()
        {
            var manager = new CardManager();
            manager.CreateCard("Що таке C#?", "Мова");

            Assert.Equal(1, manager.FlashCards.Count);
            Assert.Equal("Що таке C#?", manager.FlashCards.GetAt(0).Question);
        }

        [Theory]
        [InlineData("", "Відповідь")]
        [InlineData("Питання", "  ")]
        public void CreateCard_EmptyInputs_ThrowsArgumentException(string question, string answer)
        {
            var manager = new CardManager();
            Assert.Throws<ArgumentException>(() => manager.CreateCard(question, answer));
            Assert.Equal(0, manager.FlashCards.Count);
        }

        [Fact]
        public void DeleteCard_ValidId_RemovesCardAndShiftsArray()
        {
            var manager = new CardManager();
            manager.FlashCards.Add(new FlashCard(1, "Питання 1", "Відповідь 1"));
            manager.FlashCards.Add(new FlashCard(2, "Питання 2", "Відповідь 2"));
            manager.FlashCards.Add(new FlashCard(3, "Питання 3", "Відповідь 3"));

            manager.DeleteCard(2);

            Assert.Equal(2, manager.FlashCards.Count);
            Assert.Equal(3, manager.FlashCards.GetAt(1).Id); 
        }

        [Fact]
        public void DeleteCard_InvalidId_ThrowsArgumentException()
        {
            var manager = new CardManager();
            manager.FlashCards.Add(new FlashCard(1, "П", "В"));
            Assert.Throws<ArgumentException>(() => manager.DeleteCard(99));
        }

        [Fact]
        public void ChangeCard_ValidData_UpdatesCardContent()
        {
            var manager = new CardManager();
            manager.FlashCards.Add(new FlashCard(1, "Старе", "Стара"));

            manager.ChangeCard(1, 1, "Нове");

            Assert.Equal("Нове", manager.FlashCards.GetAt(0).Question);
        }

        [Fact]
        public void FindById_ExistingId_ReturnsCorrectCard()
        {
            var manager = new CardManager();
            manager.FlashCards.Add(new FlashCard(5, "П", "В"));
            manager.FlashCards.Add(new FlashCard(10, "П2", "В2"));

            var result = manager.FindById(10);

            Assert.NotNull(result);
            Assert.Equal(10, result.Id);
        }
    }
}