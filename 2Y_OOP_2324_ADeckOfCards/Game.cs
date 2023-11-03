using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class Game
    {
        public void Gameplay()
        {
            AI ai = new AI();
            bool playerchoice = false;
            bool computerchoice = false;
            string value = "";
            bool gameround = true;
            int playerscore = 0;
            int computerscore = 0;
            int gamenumber = 1;
            bool cont = true;
            while(cont)
            {
                bool start = true;
                bool compcandraw = true;
                bool playcandraw = true;
                DeckOfCards doc = new DeckOfCards(true);
                int playervalue = 0;
                int computervalue = 0;
                Card PlayerCard = doc.drawACard();
                Card ComputerCard = doc.drawACard();
                while (gameround)
                {  
                    Console.Clear();
                    while (start)
                    {
                        Console.WriteLine($"This is round {gamenumber}");
                        Thread.Sleep(500);
                        Console.WriteLine("Distributing cards now");
                        Console.WriteLine($"your Card is the {PlayerCard.GetCardFace()} of {PlayerCard.GetCardSuit()} with a value of {PlayerCard.GetCardValue()}");
                        playervalue += PlayerCard.GetCardValue();
                        Console.WriteLine($"The computer's Card is the  {ComputerCard.GetCardFace()} of {ComputerCard.GetCardSuit()} with a value of {ComputerCard.GetCardValue()}");
                        computervalue += ComputerCard.GetCardValue();
                        start = false;
                    }
                    if (!compcandraw && !playcandraw)
                    {
                        Console.WriteLine($"The final deck values are {playervalue} for the player and {computervalue} for the computer. computing....");
                        Thread.Sleep(1500);
                        playerscore += checker(playervalue, computervalue);
                        computerscore += checker(computervalue, playervalue);
                        Console.WriteLine(Announce(playerscore, computerscore));
                        gamenumber++;
                        gameround = false;
                    }
                    if (computervalue > 21 || playervalue > 21)
                    {
                        compcandraw = false;
                        playcandraw = false;
                    }
                    if (playervalue < 21 && playcandraw)
                    {
                        playerchoice = PlayerChoice(playervalue, computervalue);
                        if (playerchoice)
                        {
                            PlayerCard = doc.drawACard();
                            Console.WriteLine($"your Card is the {PlayerCard.GetCardFace()} of {PlayerCard.GetCardSuit()} with a value of {PlayerCard.GetCardValue()}");
                            playervalue += PlayerCard.GetCardValue();
                            Console.WriteLine("The value of your deck is now " + playervalue);
                        }
                        else
                        {
                            playcandraw = false;
                        }
                       
                    }
                    if (compcandraw && computervalue < 21)
                    {
                        computerchoice = ai.Choice(computervalue, playervalue);
                        Console.WriteLine("computer is now making a choice");
                        Thread.Sleep(500);
                        if(computerchoice)
                        {
                            ComputerCard = doc.drawACard();
                            Console.WriteLine($"The computer's Card is the  {ComputerCard.GetCardFace()} of {ComputerCard.GetCardSuit()} with a value of {ComputerCard.GetCardValue()}");
                            computervalue += ComputerCard.GetCardValue();
                            Console.WriteLine("The computers deck value is now " + computervalue);
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            computerchoice = false;
                            compcandraw= false;
                            Console.WriteLine("The computer did not draw");
                            Thread.Sleep(500);
                        }
                       
                    }
                                                 
                }
                gameround = PlayAgain();
            }
        }
        private bool PlayerChoice(int value, int comp)
        {
            bool choose = false;
            Console.WriteLine("Player value = " + value);
            Console.WriteLine("Computer value = " + comp);
            Console.WriteLine($"Do you want to draw another card? Y/N");
            string choice = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case "Y":
                    choose = true;
                    break;
                case "N":
                    choose = false;
                    break;
                default:
                    Console.WriteLine("That is not a valid choice. Press any key to continue");
                    Console.ReadKey();
                    PlayerChoice(value, comp);
                    break;
            }
            return choose;

        }
        private int checker(int value, int value2) 
        {
            if (value > 21)
                return 0;
            else if (value < value2 && value2 < 21)
                return 0;
            else
                return 1;
        }
        private string Announce(int value, int value2) 
        {
            if (value > value2)
                return $"The player is winning!  Player : {value}   Computer : {value2}";
            else if (value2 > value)
                return $"The Computer is winning!  Player : {value}   Computer : {value2}";
            else
                return $"That round was a draw!  Player : {value}   Computer : {value2}";
        }
        private bool PlayAgain()
        {
            Console.Write("Do you want to play again? Y/N : ");
            string choice = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case "N":
                    return false;
                case "Y":
                    return true;
                default:
                    Console.WriteLine("That is not a valid choice");
                    Thread.Sleep(250);
                    return PlayAgain(); 
            }
        }

    }
}
