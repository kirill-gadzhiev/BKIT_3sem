using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a1 = 1;
            double b1 = 0;
            double c1 = -4;
            //1 корень
            double a2 = 1;
            double b2 = 0;
            double c2 = 0;
            //нет корней
            double a3 = 1;
            double b3 = 0;
            double c3 = 4;

            Console.WriteLine("Test SquareRoot_Simple");
            findroots r1 = new findroots();
            r1.PrintRoots(a1, b1, c1);
        }
    }
}
