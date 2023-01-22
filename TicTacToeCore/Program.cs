// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using TicTacToeCore;

IBoardOperation _boardOperation = new BoardOperation();


string[,] game_board;
int turnCounter;


bool continueGame = true;

while (continueGame)
{
    game_board = new string[3, 3]
     {
            { "00", "01", "02", },
            { "10", "11", "12", },
            { "20", "21", "22", },
     };
    turnCounter = 0;

    while (continueGame)
    {
        if (turnCounter % 2 == 0) //Player 1 turn
        {
            PlayerTurn("X ");
            if (_boardOperation.CheckForThree("X ", game_board))
            {
                EndGame("Player 1 Wins.");
                break;
            }
        }
        else //Player 2 turn
        {
            PlayerTurn("0 ");
            if (_boardOperation.CheckForThree("0 ", game_board))
            {
                EndGame("Player 2 Wins.");
                break;
            }
        }
        turnCounter++;

        if (_boardOperation.CheckForFullBoard(game_board))
        {
            EndGame("Draw.");
            break;
        }
    }

    Console.WriteLine("\nIf you continue press 1 and any other digit to quit!!");
    var input = Console.ReadKey();
    Console.WriteLine("\n");

    switch (input.Key)
    {
        case ConsoleKey.NumPad1:
        case ConsoleKey.D1:
            break;
        default:
            continueGame = false;
            break;
    }
}


void PlayerTurn(string ch)
{
    bool moved = false;
    while (!moved)
    {
        Console.Clear();
        RenderBoard();

        Console.WriteLine(ch.Equals("X ") ? "Player 1's turn :" : "Player 2's turn :");

        Console.WriteLine("Choose a free position to enter : ", ch);

        var input = Console.ReadLine();
        switch (input)
        {
            case "00":
            case "01":
            case "02":
            case "10":
            case "11":
            case "12":
            case "20":
            case "21":
            case "22":
                char[] inputArr = input.ToArray();
                if (game_board[inputArr[0] - '0', inputArr[1] - '0'] != "X ")
                {
                    game_board[inputArr[0] - '0', inputArr[1] - '0'] = ch;
                    moved = true;
                }
                else
                    Console.WriteLine("Position is filled with : ", game_board[inputArr[0], inputArr[1]]);
                break;
            default:
                Console.WriteLine("Invalid option!");
                break;
        }
    }
}

void RenderBoard()
{
    Console.WriteLine("Player1:X and Player2:O");
    //Console.WriteLine("Go to left/right/up/down through the respective arrows:");
    Console.WriteLine();
    Console.WriteLine($"{game_board[0, 0]} | {game_board[0, 1]} | {game_board[0, 2]}");
    Console.WriteLine("   |    |");
    Console.WriteLine("---|----|---");
    Console.WriteLine("   |    |");
    Console.WriteLine($"{game_board[1, 0]} | {game_board[1, 1]} | {game_board[1, 2]}");
    Console.WriteLine("   |    |");
    Console.WriteLine("---|----|---");
    Console.WriteLine("   |    |");
    Console.WriteLine($"{game_board[2, 0]} | {game_board[2, 1]} | {game_board[2, 2]}");
}

bool CheckForThree(string c, string[,] board)
{
    return board[0, 0] == c && board[1, 0] == c && board[2, 0] == c ||
    board[0, 1] == c && board[1, 1] == c && board[2, 1] == c ||
    board[0, 2] == c && board[1, 2] == c && board[2, 2] == c ||
    board[0, 0] == c && board[0, 1] == c && board[0, 2] == c ||
    board[1, 0] == c && board[1, 1] == c && board[1, 2] == c ||
    board[2, 0] == c && board[2, 1] == c && board[2, 2] == c ||
    board[0, 0] == c && board[1, 1] == c && board[2, 2] == c ||
    board[2, 0] == c && board[1, 1] == c && board[0, 2] == c;
}
    

bool CheckForFullBoard(string[,] board)
{
    return board[0, 0] != "00" && board[1, 0] != "10" && board[2, 0] != "20" &&
    board[0, 1] != "01" && board[1, 1] != "11" && board[2, 1] != "21" &&
    board[0, 2] != "02" && board[1, 2] != "12" && board[2, 2] != "22";

}

void EndGame(string message)
{
    Console.Clear();
    RenderBoard();
    Console.WriteLine();
    Console.Write(message);
}