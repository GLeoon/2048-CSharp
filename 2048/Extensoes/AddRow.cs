using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Extensoes
{
    public static class AddRow
    {
        public static void AddRowInMatriz(this int[,] arrayRow ,int row,params int[] itens)
        {
            if (arrayRow.GetLength(0) < itens.Length) throw new IndexOutOfRangeException();
            for (int i = 0; i < itens.Length; i++)
            {
                arrayRow[row, i] = itens[i];
            }
        }
    }
}
