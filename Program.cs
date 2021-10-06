using System;

namespace Casino_Game
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("Welcome to the Craps Game!");
            int diceNum = diceSide();
            int rollCount = 1;
            while (true)
            {
                
                Console.WriteLine($"\nRoll {rollCount}");
                int die1 = RollResult(diceNum);
                int die2 = RollResult(die1);
                int sum = die1 + die2;
                Console.WriteLine($"You rolled a {die1} and a {die2} \n" +
                    $"(Total: {sum}) \n");
                if (diceNum == 6)
                {
                    isSix(die1, die2);
                }

              if (!keepPlaying())
               {
                    break;
                }
                rollCount = rollCount + 1;

            }
        }

        public static int diceSide()
        {
            int validSides = 0;
            while (true)
            {
                Console.WriteLine("How many sides would you like on your dice? \n" +
                    "Please select a number between 4-100: ");
               
                string sides = Console.ReadLine();
                bool isValid = int.TryParse(sides, out validSides);
                
                if(isValid == true)
                {
                    if (validSides > 3 && validSides < 101)
                    { Console.WriteLine($"You have selected {validSides} sided dice \n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Your number is out of the range \n");
                    }
                }
               
                else
                {
                    Console.WriteLine("That is not a number. Please select a number \n");
                }
            }

            return validSides;
        }


        public static bool keepPlaying()
        {
            bool keepRunning = true;
            while (true)
            {
               
                 Console.WriteLine("Would you like to keep playing? Y / N");
                string response = Console.ReadLine().ToLower();
                if(response == "y")
                {
                    keepRunning = true;
                    break;

                }
                else if(response == "n")
                {
                    keepRunning = false;
                    break;
                }

                else
                {
                    Console.WriteLine("That is not a valid input. Please enter Y or N.");
                }
            }
            return keepRunning;
        }

        public static void isSix(int die1, int die2)
        {
            string message = "";
            if (die1 == 1 && die2 == 1)
            {
                Console.WriteLine("OH NO! You rolled snake eyes");
            }

            else if(die1 == 1 && die2 == 2)
            {
                Console.WriteLine("You rolled an Ace Deuce");
            }

            else if(die1 == 6 && die2 == 6)
            {
                Console.WriteLine("You rolled box cars");
            }

            else if(die1 + die2 == 7 || die1 + die2 == 11)
            {
                Console.WriteLine("YOU WIN! Tood bad this isn't a real Casino");
            }

            if (die1 + die2 == 2 || die1 + die2 == 3 || die1 + die2 == 12)
            {
                Console.WriteLine("You rolled craps!"); 
            }

            Console.WriteLine(message);

        }
        public static int RollResult(int dr)
        {   
            
            Random rd = new Random();
            int result = rd.Next(1, dr+1);
            return result;                                   
        }
    }
}
