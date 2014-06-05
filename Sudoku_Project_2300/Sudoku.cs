using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Project_2300
{
    class Sudoku
    {
        // variables
        private List<String> board = new List<String>();

        // Member Methods

        // The AddLine method
        // Purpose: Insert rows into the board
        public void AddLine(string line)
        {
            board.Add(line);
        }

        // The GetBoard method
        // Purpose: Return the board as a list of strings
        public List<String> GetBoard()
        {
            return board;
        }

    }
}
