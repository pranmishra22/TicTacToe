using System;
namespace TicTacToeCore
{
	public class BoardOperation : IBoardOperation
    {
        public bool CheckForThree(string c, string[,] board)
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


        public bool CheckForFullBoard(string[,] board)
        {
            return board[0, 0] != "00" && board[1, 0] != "10" && board[2, 0] != "20" &&
            board[0, 1] != "01" && board[1, 1] != "11" && board[2, 1] != "21" &&
            board[0, 2] != "02" && board[1, 2] != "12" && board[2, 2] != "22";

        }
    }
}

