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
        const int NINE = 9;
        private string[] board = new string[NINE];
        private int[] checkAgainst = new int[NINE];


        // Member Methods

        // The CheckRow method
        // Purpose: Check that the current row is valid
        public bool CheckRow(int row)
        {
            //Sets all values of the array to 0
            for (int i = 0; i < NINE; i++)
                checkAgainst[i] = 0;

            //
            for (int i = 0; i < NINE; i++)
            {
                if ((int)char.GetNumericValue(board[row][i]) != -1)
                {
                    //if there is more than one of the same number, then return false
                    if (checkAgainst[((int)char.GetNumericValue(board[row][i])) - 1] >= 1)
                    {
                        return false;
                    }
                    else
                        //add 1 to number of timmes the number appears in the column
                        checkAgainst[(int)char.GetNumericValue(board[row][i]) - 1] = 1;
                }
            }
            return true;
        }

        // The CheckCol method
        // Purpose: Check that the current column is valid
        public bool CheckCol(int col)
        {
            //create an array to count how many instances of a number appears in a column
            for (int i = 0; i < NINE; i++)
                checkAgainst[i] = 0;

            for (int i = 0; i < NINE; i++)
            {
                if ((int)char.GetNumericValue(board[i][col]) != -1)
                {
                    //if there is more than one of the same number, then return false
                    if ((checkAgainst[(int)char.GetNumericValue(board[i][col]) - 1]) >= 1)
                        return false;
                    //add 1 to number of timmes the number appears in the column
                    checkAgainst[(int)char.GetNumericValue(board[i][col]) - 1] += 1;
                }
            }
            return true;
        }

        // The CheckSquare method
        // Purpose: Check that the 9x9 square is valid
        public bool CheckSquare(int row, int col)
        {
            int r = 0, c = 0;

            //count how many numbers are in the square
            for (int i = 0; i < 9; i++)
                checkAgainst[i] = 0;

            for (r = row; r < row + 3; r++)
            {
                for (c = col; c < col + 3; c++)
                {
                    //check for existing numbers in the square
                    if ((int)char.GetNumericValue(board[r][c]) != -1)
                    {
                        //return false if there is a duplicate number
                        if ((checkAgainst[(int)char.GetNumericValue(board[r][c]) - 1]) >= 1)
                            return false;
                        //add that the number exists in the square
                        checkAgainst[(int)char.GetNumericValue(board[r][c]) - 1] = 1;
                    }
                }
            }
            return true;
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
            while (row < 9 && (int)char.GetNumericValue(board[row][col]) != -1)
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
                newstring[col] = i.ToString()[0];

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
