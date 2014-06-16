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
        private string[] board = new string[9];
        private int[] checkAgainst = new int[9];

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
            //create an array to count how many instances of a number appears in a column
            for (int i = '0'; i <= '9'; i++) 
                checkAgainst[i] = 0;

            for (int i = 0; i < 9; i++)
            {
                if (board[i].ElementAt(col) != '*')
                {
                    //if there is more than one of the same number, then return false
                    if ((checkAgainst[board[i].ElementAt(col)])>=1) 
                        return false;
                    //add 1 to number of timmes the number appears in the column
                    checkAgainst[board[i].ElementAt(col)] += 1;
                }
            }
            return true;
        }

        // The CheckSquare method
        // Purpose: Check that the 9x9 square is valid
        public bool CheckSquare(int sr, int sc)
        {
            return false;
        }

        // The AddLine method
        // Purpose: Insert rows into the board
        public void AddLine(string line, int row)
        {
            board[row] = line;
        }

        // The GetBoard method
        // Purpose: Return the board as an array of strings
        public string[] GetBoard()
        {
            return board;
        }

        // The SolveRecursively method
        // Purpose: Solve the puzzle recursively.  
        public bool SolveRecursively (int row, int col)
        {
            // Advance through columns and rows until a blank spot is found
            //while(row < 9 and the current spot is not a blank)
            while (row < 9 && board.ElementAt(row).ElementAt(col) != '*')
            {

                // go to the next column
                col++;

                // if in column 9, move to the next row
                if (col == 9)
                {
                    // move to the next row
                    row++;
                    // start in the first column
                    col = 0;
                }

            }

            // If row = 9, we have processed all rows (0-8) and the solve is complete.  
            if (row == 9)
            {
                return true;
            }

            // otherwise
            // try values 1-9 and check row, column, and square
            for (int i = 1; i <= 9; i++)
            {
                StringBuilder newstring = new StringBuilder(board[row]);
                newstring[col] = (char)i;

                board[row] = newstring.ToString();

                // If successful, return true
                if (CheckRow(row) && CheckCol(col) && CheckSquare(row-(row%3), col-(col%3)) && SolveRecursively(row, col))
                {
                    return true;
                }
                
                // Else, try the next value (go through the loop again)
            }

            // If we get here, we tried all the values 1-9 for this space and none of them worked.  We have to reset this to blank
            // return false and go back to square 1 :(

            StringBuilder newRow = new StringBuilder(board[row]);
            newRow[col] = '*';
            board[row] = newRow.ToString();
            return false;
        }
    }
}
