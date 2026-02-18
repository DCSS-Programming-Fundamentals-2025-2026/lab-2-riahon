using System;
using FlashCards.Domain.Core;
using FlashCards.App; 

namespace FlashCards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Menu appMenu = new Menu();
            appMenu.Run();
        }
    }
}