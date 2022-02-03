using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public class Program
    {
        static void Main(string[] args)
        {

            var randomNumberTable = new RandomNumber(3);

            int c = randomNumberTable.newArray.GetLength(0);
            int i = randomNumberTable.newArray.Rank;
            Console.WriteLine(i);
            Console.WriteLine(c);

            var scren = new ShowGame(randomNumberTable.newArray);
            var Move = new MakeMove();
            scren.ShowGameConsole();

            //int[,] returnedMatriz = new int[4, 4];
            while (true)
            {
                string Key = Console.ReadLine();

                if (Key == "a" || Key == "A") randomNumberTable.newArray = Move.MoveLeft(randomNumberTable.newArray);
                if (Key == "s" || Key == "S") randomNumberTable.newArray = Move.MoveDown(randomNumberTable.newArray);
                if (Key == "d" || Key == "D") randomNumberTable.newArray = Move.MoveRight(randomNumberTable.newArray);
                if (Key == "w" || Key == "W") randomNumberTable.newArray = Move.MoveUp(randomNumberTable.newArray);
                if (Move.sumOcurred == false) randomNumberTable.DropNumber(1);

                try
                {
                    var s = new ShowGame(randomNumberTable.newArray);
                    s.ShowGameConsole();

                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("key pressed is not valid.please retype (W, A, S or D)");
                    continue;
                }
            }
        }
    }
}
