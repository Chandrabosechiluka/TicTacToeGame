using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Models
{
    public class TicTacToeFacade
    {
        private TicTacToe game;
        private Player playerOne;
        private Player playerTwo;

        public TicTacToeFacade(string playerOneName, string playerTwoName)
        {
            game = new TicTacToe();
            playerOne = new Player(playerOneName, 'X');
            playerTwo = new Player(playerTwoName, 'O');
        }

        public void StartGame()
        {
            bool isGameOver = false;

            while (true)
            {
                if (isGameOver)
                {
                    Console.WriteLine("Do you want to play again?..... (yes or no):");
                    string response = Console.ReadLine().Trim().ToLower();

                    if (response == "yes")
                    {
                        game.ResetGame();
                        isGameOver = false;
                        Console.WriteLine("New game started!");
                    }
                    else
                    {
                        Console.WriteLine("Thanks for playing!");
                        break;
                    }
                }

                Player currentPlayer = playerOne;
                game.SetCurrentPlayer(currentPlayer);

                while (!isGameOver)
                {
                    Console.WriteLine("Current board:");
                    PrintBoard();
                    Console.WriteLine($"{currentPlayer.Name}'s turn. Enter row and column (0, 1, or 2):");

                    if (!TryGetPlayerMove(out int row, out int column))
                    {
                        continue;
                    }

                    if (!game.PlaceMark(row, column))
                    {
                        Console.WriteLine("Invalid move, try again.");
                        continue;
                    }

                    if (game.CheckWinner())
                    {
                        Console.WriteLine($"{currentPlayer.Name} wins!");
                        PrintBoard();
                        isGameOver = true;
                        break;
                    }

                    if (game.IsDraw())
                    {
                        Console.WriteLine("It's a draw!");
                        PrintBoard();
                        isGameOver = true;
                        break;
                    }

                    currentPlayer = (currentPlayer == playerOne) ? playerTwo : playerOne;
                    game.SetCurrentPlayer(currentPlayer);
                }
            }
        }

        private bool TryGetPlayerMove(out int row, out int column)
        {
            row = 0;
            column = 0;

            if (int.TryParse(Console.ReadLine(), out row) && int.TryParse(Console.ReadLine(), out column))
            {
                if (row >= 0 && row < 3 && column >= 0 && column < 3)
                {
                    return true;
                }
            }

            Console.WriteLine("Invalid input. Please enter numeric values for row and column.");
            return false;
        }

        private void PrintBoard()
        {
            char[,] board = game.GetBoard();
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    Console.Write(board[row, column] == '\0' ? "-" : board[row, column].ToString());
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }

}
