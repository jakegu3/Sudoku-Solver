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
            //while(row < 9 and the current spot is not a blank)
            //      go to the next column
            //      if in column 9, move to the next row


            // If row = 9, we have processed all rows (0-8) and the solve is complete.  

            // otherwise
            // try values 1-9 and check row, column, and square
            // 


            return 0;
        }
    }
}
