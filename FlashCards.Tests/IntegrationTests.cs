using System;
using System.IO;
using Xunit;
using FlashCards.Domain.Core;

namespace FlashCards.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void CreateCardsAndRunQuiz_ReturnsCorrectScore()
        {
            var manager = new CardManager();
            manager.CreateCard("Скільки буде 2+2?", "4");
            manager.CreateCard("Якого кольору небо?", "Синє");

            var quiz = new Test(manager.FlashCards.ToArray());

            var simulatedUserInput = "1\n1\n";
            var originalInput = Console.In;
            Console.SetIn(new StringReader(simulatedUserInput));

            try
            {
                quiz.Start(2);
                Assert.Equal(2, quiz.Score);
            }
            finally
            {
                Console.SetIn(originalInput);
            }
        }

        [Fact]
        public void DeleteCardAndRunQuiz_OnlyTestsRemainingCards()
        {
            var manager = new CardManager();
            manager.FlashCards.Add(new FlashCard(1, "Питання 1", "Відповідь 1"));
            manager.FlashCards.Add(new FlashCard(2, "Питання 2", "Відповідь 2"));
            manager.FlashCards.Add(new FlashCard(3, "Питання 3", "Відповідь 3"));

            manager.DeleteCard(2);

            var quiz = new Test(manager.FlashCards.ToArray());

            var simulatedUserInput = "1\n1\n";
            var originalInput = Console.In;
            Console.SetIn(new StringReader(simulatedUserInput));

            try
            {
                quiz.Start(10);
                Assert.Equal(2, quiz.Score);
            }
            finally
            {
                Console.SetIn(originalInput);
            }
        }
    }
}