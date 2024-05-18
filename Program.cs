using static System.Console;
using Spectre.Console;
Random random = new Random();

Main();


void Main()
{
    AnsiConsole.MarkupLine("[bold yellow]Welcome to Sequence Challenge![/]");
    AnsiConsole.MarkupLine("[bold yellow][[1]][/] Start Game");
    AnsiConsole.MarkupLine("[bold yellow][[2]][/] Difficulty");
    AnsiConsole.MarkupLine("[bold yellow][[3]][/] Exit");

    switch (ReadKey().KeyChar)
    {
        case '1':
            StartGame();
            break;
        case '2':
            Difficulty();
            break;
        case '3':
            Clear();
            AnsiConsole.MarkupLine("[bold italic yellow]Bye![/]");
            CleanUpUi(1500);
            break;
    }
}

string GetRandomColorMarkup(string text)
{
    var colors = new[] { "red", "green", "blue", "yellow", "magenta", "cyan" };
    string randomColor = colors[random.Next(colors.Length)];
    return $"[{randomColor}]{text}[/]";
}

void StartGame(int difficulty = 4)
{
    Clear();

    do
    {
        int[] randomNumber = GnerateRandomNumber(difficulty);
        int score = 0;
        ShowNumber(randomNumber);

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
                    AnsiConsole.MarkupLine("[bold green]Correct[/] :check_mark:");
                    CleanUpUi();
                    score++;
                }
                else
                {
                    score++;
                    AnsiConsole.MarkupLine("[bold red]Wrong[/] :cross_mark:");
                    CleanUpUi();
                }
            } while (gusserInput != randomNumber[i]);
        }
        AnsiConsole.MarkupLine($"You Score: [bold yellow]:star: {score}[/]");
        WriteLine("Would you like to play again?");
        if (ReadKey().KeyChar == 'n')
        {
            Clear();
            AnsiConsole.MarkupLine("[bold italic yellow]Thanks for playing![/] :sparkling_heart:");
            CleanUpUi(1500);
            break;
        }
        
    } while (true);
}

int[] GnerateRandomNumber(int length = 4)
{
    int[] randomNumber = new int[length];

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
        AnsiConsole.Markup(GetRandomColorMarkup(number.ToString()));
        Thread.Sleep(1000);
        Clear();
    }
}
void CleanUpUi(int CleanSpped = 400)
{
    Thread.Sleep(CleanSpped);
    Clear();
}
void CustomDifficulty()
{
    Console.Clear();
    Console.WriteLine("How many numbers would you like in your sequence ?");
    if (int.TryParse(Console.ReadLine(), out int difficulty))
    {
        StartGame(difficulty);
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }
}
void Difficulty()
{
    Clear();
    AnsiConsole.MarkupLine("[bold yellow][[1]][/] Easy (4 numbers)");
    AnsiConsole.MarkupLine("[bold yellow][[2]][/] Medium (6 numbers)");
    AnsiConsole.MarkupLine("[bold yellow][[3]][/] Hard (8 numbers)");
    AnsiConsole.MarkupLine("[bold yellow][[4]][/]Choose a difficulty: ");
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
        case '4':
            CustomDifficulty();
            break;
        default:
            Main();
            break;
    }
}