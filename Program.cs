using Microsoft.VisualBasic;

namespace Dice_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice, answer;
            bool done = false;
            double money, bet;
            int choiceNum, rollTotal;
            choiceNum = 0;
            money = 100;
            Die die1 = new Die();
            Die die2 = new Die();

            Console.WriteLine("Hello, ready for a fun little game? Let's play.");
            Console.WriteLine("The rules are simple, you make a bet and guess the outcome of a roll of a pair of dice. If you're right, you win money, if you're wrong, you lose money");
            Thread.Sleep(750);
            Console.WriteLine("There are four possible outcomes you can guess from:");
            Thread.Sleep(750);
            Console.WriteLine("Doubles - The dice both roll the same number (On a win, you get double your bet)"); // choiceNum = 1
            Thread.Sleep(750);
            Console.WriteLine("Not Doubles - The dice roll different numbers (On a win, you get half your bet)"); // choiceNum = 2
            Thread.Sleep(750);
            Console.WriteLine("Even Sum - The numbers on the dice add to an even number (On a win, you get your bet)"); // choiceNum 3
            Thread.Sleep(750);
            Console.WriteLine("Odd Sum - The numbers on the dice add to an odd number (On a win, you get your bet)"); // choiceNum = 4
            Console.WriteLine("");
            Thread.Sleep(750);

            while (!done)
            {
                Console.WriteLine($"You currently have {money.ToString("C")}.");
                Console.WriteLine("Which outcome would you like to bet on? (Please type your choice)");
                choice = Console.ReadLine().ToUpper().Trim();
                while (choice != "DOUBLES" && choice != "NOT DOUBLES" && choice != "EVEN SUM" && choice != "ODD SUM")
                {
                    Console.WriteLine("Sorry, that's not a valid choice, please try again");
                    choice = Console.ReadLine().ToUpper().Trim();
                }

                if (choice == "DOUBLES")
                {
                    choiceNum = 1;
                    Console.WriteLine("You are betting that the dice will roll doubles");
                }
                else if (choice == "NOT DOUBLES")
                {
                    choiceNum = 2;
                    Console.WriteLine("You are betting that the dice will not roll doubles");
                }
                else if (choice == "EVEN SUM")
                {
                    choiceNum = 3;
                    Console.WriteLine("You are betting that the sum of the dice will be even");
                }
                else if (choice == "ODD SUM")
                {
                    choiceNum = 4;
                    Console.WriteLine("You are betting that the sum of the dice will be odd");
                }
                else
                {
                    Console.WriteLine("How did this happen?");
                    Environment.Exit(0);
                }


                Console.WriteLine("How much would you like to bet?");

                while (!Double.TryParse(Console.ReadLine().Trim(), out bet) || bet <= 0)
                {
                    Console.WriteLine("Sorry, that's not a valid bet, please try again");
                }

                Math.Round(bet, 2);
                
                if (bet > money)
                {
                    Console.WriteLine($"I'm assuming you meant to bet all your money, so I'm just going to lock in your bet as {money.ToString("C")}");
                    bet = money;
                }

                Console.WriteLine();
                Console.WriteLine("Now let's roll these dice! Press Enter to roll the dice. Good Luck!");
                Console.ReadLine();
                die1.RollDie();
                die1.DrawDie();
                die2.RollDie();
                die2.DrawDie();

                if (choiceNum == 1)
                {
                    if (die1.Roll == die2.Roll)
                    {
                        Console.WriteLine($"What do you know, doubles! Congrats, you got it right. Here's your payout of {(bet*2).ToString("C")}");
                        money += (bet * 2);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, your guess was incorrect. I'll be keping your bet of {bet.ToString("C")}");
                        money -= bet;
                    }
                }
                else if (choiceNum == 2)
                {
                    if (die1.Roll != die2.Roll)
                    {
                        Console.WriteLine($"Well done, you took the safest option and got in right. Here's your payout of {(bet/2).ToString("C")}");
                        money += Math.Round(bet/2, 2);
                    }
                    else
                    {
                        Console.WriteLine($"Wow, you actually got it wrong. Tough luck bud, but I'll be keeping your bet of {bet.ToString("C")}");
                        money -= bet;
                    }
                }
                else if (choiceNum == 3)
                {
                    rollTotal = die1.Roll + die2.Roll;
                    if (rollTotal == 2 || rollTotal == 4 || rollTotal == 6 || rollTotal == 8 || rollTotal == 10 || rollTotal == 12)
                    {
                        Console.WriteLine($"Congrats, you were correct. Here is your payout of {bet.ToString("C")}");
                        money += bet;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you were not correct. I'll be keeping your bet of {bet.ToString("C")}");
                        money -= bet;
                    }
                }
                else if (choiceNum == 4)
                {
                    rollTotal = die1.Roll + die2.Roll;
                    if (rollTotal == 3 || rollTotal == 5 || rollTotal == 7 || rollTotal == 9 || rollTotal == 11)
                    {
                        Console.WriteLine($"Congrats, you were correct. Here is your payout of {bet.ToString("C")}");
                        money += bet;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you were not correct. I'll be keeping your bet of {bet.ToString("C")}");
                        money -= bet;
                    }
                }
                else
                {
                    Console.WriteLine("Error! Closing program!");
                    Environment.Exit(0);
                }

                Console.WriteLine($"Your balance is now {money.ToString("C")}");

                if (money == 0)
                {
                    Console.WriteLine("I'm sorry, it seems you have no money left to play with, I must ask you to leave. Goodbye!");
                    Environment.Exit(0);
                }

                Console.WriteLine("Would you like to play another round? (Yes/No)");
                answer = Console.ReadLine().ToUpper().Trim();

                while (answer != "YES" && answer != "NO")
                {
                    Console.WriteLine("That is not a valid response. Please try again");
                    answer = Console.ReadLine().ToUpper().Trim();
                }

                if (answer == "YES")
                {
                    done = false;
                }
                else if (answer == "NO")
                {
                    Console.WriteLine($"Okay, your final balance was {money.ToString("C")}");
                    done = true;
                }
            }
        }
    }
}