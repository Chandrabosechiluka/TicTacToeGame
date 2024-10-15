using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Models
{
    public class TicTacToe
    {
        private char[,] board;
        private int moves;
        private Player currentPlayer;

        public TicTacToe()
        {
            board = new char[3, 3];
            moves = 0;
        }

        public bool PlaceMark(int row, int column)
        {
            if (board[row, column] == '\0')
            {
                board[row, column] = currentPlayer.Mark;
                moves++;
                return true;
            }
            return false;
        }

        public void SetCurrentPlayer(Player player)
        {
            currentPlayer = player;
        }

        public char[,] GetBoard()
        {
            return board;
        }

        public bool CheckWinner()
        {
            if (CheckRows() || CheckColumns() || CheckDiagonals())
            {
                return true;
            }
            return false;
        }

        private bool CheckRows()
        {
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] != '\0' && board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2])
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckColumns()
        {
            for (int column = 0; column < 3; column++)
            {
                if (board[0, column] != '\0' && board[0, column] == board[1, column] && board[1, column] == board[2, column])
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckDiagonals()
        {
            if (board[0, 0] != '\0' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }
            if (board[0, 2] != '\0' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }
            return false;
        }

        public bool IsDraw()
        {
            return moves == 9;
        }

        public void ResetGame()
        {
            board = new char[3, 3];
            moves = 0;
        }
    }


}
