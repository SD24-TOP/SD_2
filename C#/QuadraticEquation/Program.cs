using FirstProgram_Library;

Console.Write("Введите коф a: ");
double a = double.Parse(Console.ReadLine());
Console.Write("Введите коф b: ");
double b = double.Parse(Console.ReadLine());
Console.Write("Введите коф c: ");
double c = double.Parse(Console.ReadLine());

EquationSolver solver= new EquationSolver();

List<double> roots = solver.Solve(a, b,c);

if (roots.Count() == 2)
{
    Console.WriteLine($"x1 = {x1}; x2 = {x2}");
}
else if (roots.Count() == 1)
{
    Console.WriteLine($"1 = {x}");
}
else
{
    Console.WriteLine("корней нет");
}