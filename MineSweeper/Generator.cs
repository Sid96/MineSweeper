using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperBoardGenerator
{
    public class Generator
    {
        static void Main(string[] args)
        {
            var rowClicked = 0;
            var columnClicked = 0;
            int size = 9;
            var board = GenerateBoard(rowClicked, columnClicked, size, 10);
            WriteBoard(board, size, rowClicked, columnClicked);       
            Console.ReadKey();            
        }

        public static int[,] GenerateBoard(int rowClicked, int columnClicked, int size, int mines)
        {
            //recommended size maximum - 25
            var board = new int[size,size];                                      
            for (var i = 0; i< size; i++)
            {
                for (var j=0; j<size; j++)
                {
                    board[i, j] = 0;
                }
            }
            board[rowClicked, columnClicked] = 10;
            var randomNumberGenerated = new Random();
            for (var i = 0; i<mines; i++)
            {
                //I need to use a large number and take the modulus of it since Random.Next() uses the system clock as its seed. This means that if I use a 
                //small range and generate numbers in quick succession, the seeds used will be similar and thus the generated number will be similar.
                //
                //For proof of a large range being able to counteract this issue try the ProofOfConcept.TestRandomNumberGenerator() function.
                int mineRow;
                int mineColumn;
                do
                {
                    mineRow = randomNumberGenerated.Next(size * 100000) % size;
                    mineColumn = randomNumberGenerated.Next(size * 100000) % size;
                }
                while (board[mineRow, mineColumn] >= 9);

                board[mineRow, mineColumn] = 9;

                for (int adjRow = -1; adjRow<=1; adjRow++)
                {
                    for (int adjColumn = -1; adjColumn<=1; adjColumn++)
                    {   
                        try {
                            if (board[mineRow + adjRow, mineColumn + adjColumn] != 9)
                            {
                                board[mineRow + adjRow, mineColumn + adjColumn]++;
                            }
                        }
                        catch
                        {

                        }                            
                    }
                }
            }
            board[rowClicked, columnClicked] -= 10;
            return board;
        } 

        public static void WriteBoard(int[,] board, int size, int rowClicked, int columnClicked)
        {
            for (var i= 0; i<size; i++)
            {
                for (var j = 0; j< size; j++)
                {
                    //if (i == rowClicked && j == columnClicked)
                    //{
                    //    Console.Write("I");
                    //}
                    if (board[i, j] == 9 )
                    {
                        Console.Write("M");    
                    }
                    else
                    {
                        Console.Write(board[i, j]);
                    }
                }
                Console.WriteLine();
            }
        } 
    }
}
