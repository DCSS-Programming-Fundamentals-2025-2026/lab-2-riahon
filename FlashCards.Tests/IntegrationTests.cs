using System;
using System.IO;
using NUnit.Framework;
using FlashCards.Domain.Core;

namespace FlashCards.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
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

                // Сучасний синтаксис Assert.That
                Assert.That(quiz.Score, Is.EqualTo(2));
            }
            finally
            {
                Console.SetIn(originalInput);
            }
        }
    }
}