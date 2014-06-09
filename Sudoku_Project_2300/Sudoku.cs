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

        // The CheckRow method
        // Purpose: Check that the current row is valid
        public bool CheckRow(int row)
        {
            return false;
        }

        // The CheckCol method
        // Purpose: Check that the current column is valid
        public bool CheckCol(int col)
        {
            return false;
        }

        // The CheckSquare method
        // Purpose: Check that the 9x9 square is valid
        public bool CheckSquare()
        {
            return false;
        }

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

        // The SolveRecursively method
        // Purpose: Solve the puzzle recursively.  
        public int SolveRecursively (int row, int column)
        {
            int i = 0;

            // Advance through columns and rows until a blank spot is found


            return 0;
        }
    }
}
