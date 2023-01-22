using System;
namespace TicTacToeCore
{
	public interface IBoardOperation
	{
        bool CheckForThree(string c, string[,] board);
        bool CheckForFullBoard(string[,] board);
    }
}

