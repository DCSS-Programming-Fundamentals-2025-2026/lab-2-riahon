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
            string question = "Що таке C#?";
            string answer = "Мова програмування";

            manager.CreateCard(question, answer);

            Assert.NotNull(manager.FlashCards[0]);
            Assert.Equal(question, manager.FlashCards[0].Question);
            Assert.Equal(answer, manager.FlashCards[0].Answer);
            Assert.Equal(1, manager.FlashCards[0].Id);
        }

        [Theory]
        [InlineData("", "Відповідь")]
        [InlineData("Питання", "  ")]
        public void CreateCard_EmptyInputs_ThrowsArgumentException(string question, string answer)
        {
            var manager = new CardManager();

            var exception = Assert.Throws<ArgumentException>(() => manager.CreateCard(question, answer));
            Assert.Equal("Питання та відповідь не можуть бути порожніми.", exception.Message);
            Assert.Null(manager.FlashCards[0]);
        }

        [Fact]
        public void DeleteCard_ValidId_RemovesCardAndShiftsArray()
        {
            var manager = new CardManager();
            manager.FlashCards[0] = new FlashCard(1, "Питання 1", "Відповідь 1");
            manager.FlashCards[1] = new FlashCard(2, "Питання 2", "Відповідь 2");
            manager.FlashCards[2] = new FlashCard(3, "Питання 3", "Відповідь 3");

            manager.DeleteCard(2);

            Assert.NotNull(manager.FlashCards[1]);
            Assert.Equal(3, manager.FlashCards[1].Id);
            Assert.Null(manager.FlashCards[2]);
        }

        [Fact]
        public void DeleteCard_InvalidId_ThrowsArgumentException()
        {
            var manager = new CardManager();
            manager.FlashCards[0] = new FlashCard(1, "Питання", "Відповідь");

            Assert.Throws<ArgumentException>(() => manager.DeleteCard(99));
        }

        [Fact]
        public void ChangeCard_ValidData_UpdatesCardContent()
        {
            var manager = new CardManager();
            manager.FlashCards[0] = new FlashCard(1, "Старе питання", "Стара відповідь");

            manager.ChangeCard(1, 1, "Нове питання");

            Assert.Equal("Нове питання", manager.FlashCards[0].Question);
            Assert.Equal("Стара відповідь", manager.FlashCards[0].Answer); 
        }

        [Fact]
        public void FindById_ExistingId_ReturnsCorrectCard()
        {
            var manager = new CardManager();
            manager.FlashCards[0] = new FlashCard(5, "Питання", "Відповідь");
            manager.FlashCards[1] = new FlashCard(10, "Питання 2", "Відповідь 2");

            var result = manager.FindById(10);

            Assert.NotNull(result);
            Assert.Equal(10, result.Id);
            Assert.Equal("Питання 2", result.Question);
        }
    }
}