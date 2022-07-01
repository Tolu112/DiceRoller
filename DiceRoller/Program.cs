//DICE ROLLER. Objective: Random Numbers. Task: Create an application that simulates dice rolling.

Console.WriteLine("Hello and Welcome to the OG Casino!\n");
int NumberOfsides;
//Get number of sides for a pair of dice

while (true)
{
    try
    {
        Console.Write("How many sides should each die have? ");
        NumberOfsides = int.Parse(Console.ReadLine());
        if (NumberOfsides < 1)
        {
            //out of range
            //throw new Exception("That number was out of range'
            throw new Exception("\nThat number was out of range. Please try again.\n");
            //Achieves same thing without throwing error.
        }
        else
        {
            //in range and a number
            break;
        }
    }

    //Check for formating and other errors
    catch (FormatException e)
    {
        Console.WriteLine("\nYour selection must be a number. Please try again.\n");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

//Ask user to roll the dice and loop program
bool RollDice = true;
while (RollDice)
{
    Console.Write("\nPress any key to roll the dice: ");
    string StartRolling = Console.ReadLine();

    //Roll the dice and using a method, output random numbers
    int roll1;
    int roll2;
  
    Random rdm = new Random();
    roll1 = rdm.Next(1, NumberOfsides + 1);
    roll2 = rdm.Next(1, NumberOfsides + 1);
    int total = roll1 + roll2;
    string userResult = "";
    SixSidedDice(roll1, roll2, out userResult);

    //Display results for dice with all side counts >= 1
    Console.WriteLine($"\nYou rolled a {roll1} and a {roll2} (Total: {total})\n");

    //Method call for six sided dice wins
    if(NumberOfsides == 6)
    {
        Console.WriteLine($"{userResult}");
    }

    //Loop to roll again
    while (true)
    {
        Console.WriteLine("Would you like to roll again? y/n");
        string choice1 = Console.ReadLine().ToLower().Trim();
        if (choice1 == "y")
        {
            break;
        }
        else if (choice1 == "n")
        {
            Console.WriteLine("See you next time!");
            RollDice = false;
            break;
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }

    //Static method for six-sided dice wints
    static string SixSidedDice(int x, int y, out string result)
    {
        result = null;
        int total = x + y;

        if (x == 1 && y == 1)
        {
            result = "Snake Eyes.\n";
        }
        else if (total == 3)
        {
            result = "Ace Deuce!\n";
        }
        else if (x == 6 && y == 6)
        {
            result = "Box Cars\n";
        }
        else if (total == 7 || total == 11)
        {
            result = "Alright, a win!!!\n";
        }
        else if (total == 2 || total == 3 || total == 12)
        {
            result += "Holy, Craps!\n";
        }
        return result;
    }
}



