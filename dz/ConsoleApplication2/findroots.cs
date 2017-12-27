using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class findroots
    {
        int count = 0; //количество комплексных корней

        public List<double> CalculateRoots(double a, double b, double c)
        {
            List<double> roots = new List<double>();
            double D = b * b - 4 * a * c;
            if (D == 0)
            {
                double temp_root = -b / (2 * a);
                if (temp_root >= 0)
                {
                    double root = Math.Sqrt(temp_root);
                    roots.Add(root);
                    roots.Add(-1 * root);
                }
            }
            else if (D > 0)
            {
                double sqrtD = Math.Sqrt(D);
                double root1 = (-b + sqrtD) / (2 * a);
                double root2 = (-b - sqrtD) / (2 * a);
                if (root1 < 0)
                {
                    count += 2;
                }
                else
                {
                    root1 = Math.Sqrt(root1);
                    roots.Add(root1);
                    roots.Add(-1 * root1);
                }
                if (root2 < 0)
                {
                    count += 2;
                }
                else
                {
                    root2 = Math.Sqrt(root2);
                    roots.Add(root2);
                    roots.Add(-1 * root2);
                }

            }
            return roots;
        }

        public void PrintRoots(double a, double b, double c)
        {
            List<double> roots = this.CalculateRoots(a, b, c);
            Console.Write("Уравнение: {0}*x^4 + {1}*x^2 + {2} = 0", a, b, c);
            if (count == 4 || roots.Count == 0)
            {
                Console.WriteLine("Все корни комплексные.");
            }
            for (int i = 0; i < count; i++)
                Console.Write("x{0} - комплексный корень", i + 1);
            for (int i = 0; i < roots.Count; i++)
                Console.Write("x{0} = {2}", (i + 1 + count), roots[i]);

        }
    }
}
