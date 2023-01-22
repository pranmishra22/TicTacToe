using System;
using TicTacToeCore;

namespace TicTacToeTest
{
	public class TicTacToeTest
	{
        IBoardOperation _boardOperation = new BoardOperation();

		[Fact]
		public void CheckForThree_ShouldCalculateForWin()
		{
            //Arrange
            string[,] game_board = new string[3, 3]
            {
                { "X", "0", "0", },
                { "0", "X", "X", },
                { "X", "X", "0", },
            };
            bool expected = false;

            //Act
            bool actual = _boardOperation.CheckForThree("X ", game_board);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckForFullBoard_ShouldReturnTrueIfBoardIsFull()
        {
            //Arrange
            string[,] game_board = new string[3, 3]
            {
                { "X", "0", "X", },
                { "0", "X", "0", },
                { "X", "0", "X", },
            };
            bool expected = true;

            //Act
            bool actual = _boardOperation.CheckForFullBoard(game_board);

            //Assert
            Assert.Equal(expected, actual);
        }


    }
}

