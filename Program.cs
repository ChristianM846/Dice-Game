namespace Dice_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice;
            bool done = false;
            double money, bet;
            int choiceNum;
            money = 100;
            Die die1 = new Die();
            Die die2 = new Die();

            Console.WriteLine("Hello, ready for a fun little game? Let's play.");
            Console.WriteLine("The rules are simple, you make a bet and guess the outcome of a roll of a pair of dice. If you're right, you win money, if you're wrong, you lose money");
            Thread.Sleep(750);
            Console.WriteLine("There are four possible outcomes you can guess from:");
            Thread.Sleep(750);
            Console.WriteLine("Doubles - The dice both roll the same number (On win, you get double your bet)"); // choiceNum = 1
            Thread.Sleep(750);
            Console.WriteLine("Not Doubles - The dice roll different numbers (On win, you get half your bet)"); // choiceNum = 2
            Thread.Sleep(750);
            Console.WriteLine("Even Sum - The numbers on the dice add to an even number (On win, you get your bet)"); // choiceNum 3
            Thread.Sleep(750);
            Console.WriteLine("Odd Sum - The numbers on the dice add to an odd number (On win, you get your bet)"); // choiceNum = 4
            Console.WriteLine("");
            Thread.Sleep(750);

            while (!done)
            {
                Console.WriteLine($"You currently have {money.ToString("C")}.");
                Console.WriteLine("Which outcome would you like to bet on? (Please type your choice)");
                choice = Console.ReadLine().ToUpper();
                Console.WriteLine(choice);
                while (choice != "DOUBLES" && choice != "NOT DOUBLES" && choice != "EVEN SUM" && choice != "ODD SUM")
                {
                    Console.WriteLine("Sorry, that's not a valid choice, please try again");
                    choice = Console.ReadLine().ToUpper();
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

                while (!Double.TryParse(Console.ReadLine(), out bet) || bet < 0)
                {
                    Console.WriteLine("Sorry, that's not a valid bet, please try again");
                }

                Math.Round(bet, 2);

                if (bet > money)
                {
                    Console.WriteLine($"I'm assuming you meant to bet all your money, so I'm just going to lock in your bet of {money.ToString("C")}");
                    bet = money;
                }

            }
        }
    }
}