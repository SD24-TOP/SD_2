using FirstProgram_Library;

int number1 = 2;
float mini_float = 2.5f; 
double big_float = 0.522222f;
string word = "qwerty";
char symbol = 'q';
bool statement = true;

Console.Write("Введите число: ");
string str_input = Console.ReadLine();
if (str_input == null || str_input == "")
{
    str_input = "0";
}
int input = int.Parse(str_input!);

Console.WriteLine("Start numbers");

Even even = new Even();
List<int> evens = even.EvenList(1,input);
Console.WriteLine("End of numbers");

for (int i = 0; i < evens.Count(); i++)
{
    Console.WriteLine(evens[i]);
}
Console.WriteLine("End of numbers");

foreach (var number in evens)
{
    Console.WriteLine(number);
}
Console.WriteLine("End of numbers");

Console.WriteLine(string.Join(',',evens));


Console.WriteLine("End of numbers");
