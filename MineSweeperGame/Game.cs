using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;    
using System.Windows.Forms;
using MineSweeperBoardGenerator;

namespace MineSweeperGame
{
    public partial class Game : Form
    {                                
        int[,] board;
        bool[,] spaceChecked;
        int size;
        int unitsCleared=0;
        public Game()
        {

            InitializeComponent();
            spaceChecked = new bool[9, 9];
            for (var i =0;i<9; i++)
            {
                for (var j=0; j<9; j++)
                {
                    spaceChecked[i, j] = false;
                }
            }

            MakeButton(9);
        }
        public void MakeButton(int size)
        {
            this.size = size;

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    var button = new Button();
                    button.Name = j + "," + i;
                    button.Location = new Point(20 + i * 20, 20 + j * 20);
                    button.Size = new Size(18, 18);  
                    button.Font = new Font("Microsoft Sans Serif", 6);
                    button.MouseUp+= ButtonMouseClick;

                    this.Controls.Add(button);
                }
            }
        }
        private void ButtonMouseClick (object sender,MouseEventArgs e)
        {                                             
            var button = (Button)sender;
            var coordinates = button.Name.Split(',');
            var rowClicked = int.Parse(coordinates[0]);
            var columnClicked = int.Parse(coordinates[1]);
            switch (e.Button)
            {
                case MouseButtons.Left:                
                    if (board == null)
                    {                                                                                   
                        board = Generator.GenerateBoard(rowClicked, columnClicked, 9, 10);
                        Generator.WriteBoard(board,9,2,2);
                    }
                    unitsCleared++;
                    spaceChecked[rowClicked, columnClicked] = true;                                                                     

                    button.Enabled = false;
                    button.Text = board[rowClicked, columnClicked].ToString();           
                    if (button.Text == "0")
                    {
                        button.Text = "";
                        ShowNearbyZeroes(rowClicked, columnClicked,size);
                    }

                    if (button.Text == "9")
                    {
                        MessageBox.Show("You Lost");
                    }

                    else if (Math.Pow(9,2)-10 == unitsCleared)
                    {
                        MessageBox.Show("You Won");
                    }
                    button1.Focus();
                    break;

                case MouseButtons.Right:
                    if (button.Text == "F")
                    {
                        button.Text = "";
                        button.BackColor = default(Color);                     
                        button.UseVisualStyleBackColor = true;
                    }
                    else
                    {
                        button.Text = "F";
                        button.BackColor = Color.Red;
                    }
                    break;         
            }                                                                    
        }     

        private void ShowNearbyZeroes(int currentRow, int currentColumn, int size)
        {
            int rowBack = -1;
            int rowForward = 1;
            int colBack = -1;
            int colForward = 1;
            

            if (currentRow == 0)
            {
                rowBack = 0;
            }
            else if (currentRow == size-1)
            {
                rowForward = 0;
            }

            if (currentColumn == 0)
            {
                colBack = 0;
            }
            else if (currentColumn == size-1)
            {
                colForward = 0;
            }

            for (int row = rowBack+currentRow; row<= rowForward+currentRow; row++)
            {
                for (var col = colBack+currentColumn; col<=colForward+currentColumn; col++)
                {
                    if (!spaceChecked[row, col])
                    {
                        unitsCleared++;
                        spaceChecked[row, col] = true;
                        var button = (Button)this.Controls.Find(row + "," + col, true)[0];
                        if (board[row, col] == 0)
                        {                                 
                            ShowNearbyZeroes(row, col, size);                             
                        }
                        else
                        {    
                            button.Text = board[row, col].ToString();
                        }
                       
                        button.Enabled = false;
                    }
                }
            }       
        }

        private void Game_MouseClick(object sender, MouseEventArgs e)
        {
            
        } 

        private void Game_Load(object sender, EventArgs e)
        {

        }
    }
}
