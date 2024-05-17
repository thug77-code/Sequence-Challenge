using static System.Console;
Main();


void Main()
{
    WriteLine("Welcome to Sequence Challenge!");
    Console.WriteLine("[1] Start Game");
    Console.WriteLine("[2] Difficulty");
    Console.WriteLine("[3] Exit");

    switch (ReadKey().KeyChar)
    {
        case '1':
            StartGame();
            break;
        case '2':
            Difficulty();
            break;
    }
}

void StartGame(int difficulty = 4)
{
    Clear();

    do
    {
        int[] randomNumber = GnerateRandomNumber(difficulty);
        int score = 0;
        ShowNumber(randomNumber);
        WriteLine("Enter a number: ");

        for (int i = 0; i < randomNumber.Length; i++)
        {
            int gusserInput = 0;
            do
            {
                WriteLine($"Enter the {i+1} number: ");
                if (!int.TryParse(ReadLine(), out int userInput))
                {
                    WriteLine("Invalid input!");
                    CleanUpUi(1000);
                    continue;
                }
                if (userInput == randomNumber[i])
                {
                    gusserInput = userInput;
                    WriteLine("Correct!");
                    CleanUpUi();
                    score++;
                }
                else
                {
                    WriteLine("Wrong!");
                    CleanUpUi();
                }
            } while (gusserInput != randomNumber[i]);
        }
        WriteLine($"You got {score}");
        WriteLine("Would you like to play again?");
        if (ReadKey().KeyChar == 'n')
        {
            break;
        }
        
    } while (true);
}

int[] GnerateRandomNumber(int length = 4)
{
    int[] randomNumber = new int[length];
    Random random = new Random();

    for (int i = 0; i < randomNumber.Length; i++)
    {
        randomNumber[i] = random.Next(1, 10);
    }

    return randomNumber;
}

void ShowNumber(int[] RandomNumberArray)
{
    foreach (int number in RandomNumberArray)
    {
        WriteLine(number);
        Thread.Sleep(1000);
        Clear();
    }
}
void CleanUpUi(int CleanSpped = 400)
{
    Thread.Sleep(CleanSpped);
    Clear();
}
void Difficulty()
{
    Clear();
    Console.WriteLine("[1] Easy (4 numbers)");
    Console.WriteLine("[2] Medium (6 numbers)");
    Console.WriteLine("[3] Hard (8 numbers)");

    switch (ReadKey().KeyChar)
    {
        case '1':
            StartGame(4);
            break;
        case '2':
            StartGame(6);
            break;
        case '3':
            StartGame(8);
            break;
    }
}