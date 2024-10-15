using TicTacToeGame.Models;

namespace TicTacToeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            TicTacToeFacade game = new TicTacToeFacade("Player One", "Player Two");
            game.StartGame();
        }
    }
}
