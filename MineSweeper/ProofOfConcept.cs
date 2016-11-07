using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperBoardGenerator
{
    class ProofOfConcept
    {
        public static void TestRandomNumberGenerator()
        {
            var randomNumber = new Random();
            var repetition = 0;
            var list = new List<int>();

            for (var i = 0; i <= 1000000; i++)
            {
                list.Add(randomNumber.Next(800000));
            }
            for (int i = 0; i < 1000000; i++)
            {
                if (list[i] == list[i + 1])
                {
                    repetition++;
                }
            }
            Console.WriteLine(repetition);
        }                                 
    }
}
