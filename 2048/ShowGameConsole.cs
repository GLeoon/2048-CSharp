using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public class ShowGame
    {
        private int[,] Matriz;

        public ShowGame(int[,] matriz)
        {
            Matriz = matriz;

            if (matriz == null)
            {
                throw new ArgumentNullException();
            }

        }

        public void ShowGameConsole()
        {
            string tempstr = IdentifyLargest();
            Console.WriteLine($"The array has {Matriz.Rank} dimensions.");
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    string tempStrPointer = Convert.ToString(Matriz[i, j]);
                    string Space = "";

                    for (int h = 0; h < tempstr.Length - tempStrPointer.Length; h++)
                    {
                        Space += " ";
                    }
                    Console.Write(Matriz[i, j] + Space + "|");
                }
                Console.WriteLine("");
            }
        }
        private string IdentifyLargest()
        {

            int temp = 0;
            foreach (var item in Matriz)
            {
                if (item > temp) temp = item;

            }
            string tempstr = Convert.ToString(temp);
            return tempstr;

        }

    }
}
