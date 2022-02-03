using _2048.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public class MakeMove
    {
       // public string Direction { get;  set; }
        //public int[,] Matriz { get; set; }
        //public int[,] NewMatriz { get; set; }
        public bool sumOcurred { get; private set; }
        public MakeMove()
        {
            //Direction = direction;
            //Matriz = matriz ?? throw new ArgumentNullException("Array");
        }


        public int[,] MoveLeft(int[,] matriz)
        {
            //int[] RowMatriz;
            //int[] RowMatrizMoved;
            var MatrizTemp = new int[4, 4];
            int DimensionMatriz = matriz.GetLength(0);
            for (int i = 0; i < DimensionMatriz; i++)
            {
                int[] RowMatriz = matriz.GetRow(i);
                int[] RowMatrizMoved = MoveSideRow(RowMatriz);
                RowMatrizMoved = CheckNumberIsEqual(RowMatrizMoved);
                RowMatrizMoved = MoveSideRow(RowMatrizMoved);

                MatrizTemp.AddRowInMatriz(i, RowMatrizMoved);

            }
            return MatrizTemp;
        }

        public int[,] MoveRight(int[,] matriz)
        {
            int[,] reversedArray = reverseMatriz(matriz);
            reversedArray = MoveLeft(reversedArray);
            reversedArray = reverseMatriz(reversedArray);

            return reversedArray;

        }

        public int[,] MoveUp(int[,] matriz)
        {
            int[,] transposedArray = transposeMatriz(matriz);
            transposedArray = MoveLeft(transposedArray);
            transposedArray = transposeMatriz(transposedArray);

            return transposedArray;
        }
        public int[,] MoveDown(int[,] matriz)
        {
            int[,] tempArray = transposeMatriz(matriz);
            tempArray = reverseMatriz(tempArray);
            tempArray = MoveLeft(tempArray);
            tempArray = reverseMatriz(tempArray);
            tempArray = transposeMatriz(tempArray);

            return tempArray;
        }

        public int[] MoveSideRow(int[] Row)
        {
            for (int i = 0; i < Row.GetLength(0); i++)
            {
                if (Row[i] != 0 && i != 0)
                {
                    if(Row[i-1] == 0)
                    {
                        Row[i - 1] = Row[i];
                        Row[i] = 0;
                        i = 0;
                    }
                }
            }

            return Row;
        }

        private int[] CheckNumberIsEqual(int[] Row)
        {
            sumOcurred = false;
            for (int i = 0; i < Row.GetLength(0) - 1; i++)
            {
                if (Row[i] == Row[i + 1] && Row[i] != 0)
                {
                    Row[i] *= 2;
                    Row[i + 1] = 0;
                    sumOcurred = true;
                }
            }
            return Row;
        }

        private int[,] reverseMatriz(int[,] matriz)     //inverte matriz na horizontal
        {
            var reversedArray = new int[4, 4];
            int DimensionMatriz = matriz.GetLength(0);
            for (int i = 0; i < DimensionMatriz; i++)
            {
                int[] RowMatriz = matriz.GetRow(i);
                Array.Reverse(RowMatriz);
                reversedArray.AddRowInMatriz(i, RowMatriz);
            }
            return reversedArray;
        }

        private int[,] transposeMatriz(int[,] matriz)       //inverte matriz na vertical
        {
            int[,] matrizTemp = new int[4, 4];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(0); j++)
                {
                    int temp = matriz[j, i];
                    matrizTemp[j, i] = matriz[i, j];
                    matrizTemp[i, j] = temp;
                }
            }

            return matrizTemp;
        }
    }
}
