using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sudoku_Project_2300
{
    public partial class Form1 : Form
    {

        Sudoku ourPuzzle = new Sudoku();

        public Form1()
        {
            InitializeComponent();
        }

        // Display program information
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recursive Sudoku Solver\nCS 2300 Group Project\nMarc, Jake, Doug, Luke");
        }

        // Close the program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Displays information on how to use the program
        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewBox.Text = "Create a text file of the sudoku puzzle you want to solve.  \n\nValid Input should Consist of 9 rows of 9 characters.\nFor a blank spot on the puzzle, enter *";
        }

        private void inputBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                // READ IN THE TEXT FILE 
                string filename = openFileDialog1.FileName;
                ReadInFile(filename);

                // Display the Sudoku Puzzle in the view window
                DisplayBoard(ourPuzzle.GetBoard());

                // Disable the input file selector
                inputBtn.Enabled = false;
                checkMark1.Visible = true;

                // Make the filename visible
                filename = Chop(filename);
                fileLabel.Text = filename;
                fileLabel.Visible = true;

                // Enable the Solve Button
                solveBtn.Enabled = true;


                // TEST THE INPUT TO MAKE SURE IT IS A VALID SUDOKU PUZZLE

                // DISPLAY THE SUDOKU PUZZLE IN THE VIEWING WINDOW
            }

            else
            {
                MessageBox.Show("No file selected, or unable to open the selected file...");
            }
        }

        private void ReadInFile (string file)
        {
            StreamReader reader = new StreamReader(file);
            
            while(reader.Peek() >= 0)
            {
                ourPuzzle.AddLine(reader.ReadLine());
            }
        }

        private void DisplayBoard (List<String> board)
        {
            string toDisplay = "";

            for (int i = 0; i < board.Count(); i++)
            {
                toDisplay += board.ElementAt(i);
                toDisplay += "\r\n";
            }

            viewBox.Text = toDisplay;
        }

        private String Chop(string s)
        {
            Stack<char> st = new Stack<char>();

            for (int i = s.Length-1; i >= 0; i--)
            {
                if (s[i].Equals('\\'))
                {
                    break;
                }

                else
                {
                    st.Push(s[i]);
                }
            }

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < st.Count-1; i++)
            {
                sb.Append(st.Pop());
            }

            s = "Chosen File: ";
            s += sb.ToString();
            return s;
        }
    }
}
