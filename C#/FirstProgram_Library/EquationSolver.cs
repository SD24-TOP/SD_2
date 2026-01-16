using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProgram_Library
{
    public class EquationSolver
    {
        /// <summary>
        /// Метод решения уравнения
        /// </summary>
        /// <param name="a">коэф. 1</param>
        /// <param name="b">коэф. 2</param>
        /// <param name="c">коэф. 3</param>
        /// <returns>Корни уравнения</returns>
        public List<double> Solve(double a,double b,double c)
        {
            double D = b * b - 4 * a * c;
            if (D > 0)
            {
                double x1 = (-b + Math.Sqrt(D)) / (2 * a);
                double x2 = (-b - Math.Sqrt(D)) / (2 * a);

                Console.WriteLine($"x1 = {x1}; x2 = {x2}");
            }
            else if (D == 0)
            {
                double x = -b / 2 * a;
                Console.WriteLine($"1 = {x}");
            }
            else
            {
                Console.WriteLine("корней нет");
            }
            //a=0 - линейное
            //a=0, b=0 - Нет решений

            return new List<double>();
        }
    }
}
