using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Models
{
    public class Player
    {
        public string Name { get; }
        public char Mark { get; }

        public Player(string name, char mark)
        {
            Name = name;
            Mark = mark;
        }
    }

}
