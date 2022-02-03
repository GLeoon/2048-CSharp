using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public class RandomNumber
    {
        public int[,] newArray = new int[4, 4]
           {
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
           };
        Random r = new Random();

        public RandomNumber(int numberPoints)
        {
            DropNumber(numberPoints);
        }

        public void DropNumber(int numberPoints)
        {
            var axes = RafflerPoints(numberPoints);
            for (int i = 0; i < numberPoints; i++)
            {
                newArray[axes[i*2], axes[i*2 + 1]] = RandomNewNumber();
            }
        }
        public int RandomNewNumber()
        {
            if (r.Next(0,6) > 2)
            {
                return 2;
            }
            else 
            {
                return 4;
            }
        }

        public List<int> RafflerPoints(int numberSpots)
        {
            //int voidPoints = CheckEndGame();
            List<int> axes= new List<int>();

            for (int i = 0; i < numberSpots; i++)
            {
                int rowNumber = r.Next(0, 3);
                int colNumber = r.Next(0, 3);
                if (newArray[rowNumber, colNumber] == 0)
                {
                    axes.Add(rowNumber);
                    axes.Add(colNumber);
                }
                else
                {
                    i--;
                }

            }
            return axes;
        }

        //public bool CheckEndGame()
        //{
        //    int[,] matrizTemp = new int[4, 4];
        //    for (int i = 0; i < matrizAleatoria.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrizAleatoria.GetLength(0); j++)
        //        {
                    
        //        }
        //    }
        //}
    }
}
