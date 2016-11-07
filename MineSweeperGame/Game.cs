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
        int size;
        public Game()
        {

            InitializeComponent();

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
                    button.Name = i + "," + j;
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
            Console.WriteLine("Test");
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
                    }                                                                              

                    button.Enabled = false;
                    button.Text = board[rowClicked, columnClicked].ToString();           
                    if (button.Text == "0")
                    {
                        ShowNearbyZeroes(rowClicked, columnClicked,size);
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

        private static void ShowNearbyZeroes(int currentRow, int currentColumn, int size)
        {
            int rowBack = -1;
            int rowForward = 1;
            int colBack = -1;
            int colForward = 1;
            
            //for (int i = -1; i)       
        }

        private void Game_MouseClick(object sender, MouseEventArgs e)
        {
            
        } 

        private void Game_Load(object sender, EventArgs e)
        {

        }
    }
}
