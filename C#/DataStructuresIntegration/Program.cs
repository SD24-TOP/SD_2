using DataStructures.List;

Console.WriteLine("Int test");
TestIntValues();
Console.WriteLine("String test");
TestStringValues();

static void TestIntValues()
{
    MyLinkedList<int> values = new MyLinkedList<int>();

    Console.WriteLine("===Case 1: Empty list===");
    Console.WriteLine(values.Contains(0));
    Console.WriteLine(values.Count());
    values.Remove(0);

    Console.WriteLine("===Case 2: Added 3 elements===");
    values.Add(1);
    values.Add(2);
    values.Add(3);
    Console.WriteLine(values.Contains(1));
    Console.WriteLine(values.Count());

    Console.WriteLine("===Case 3: Removed 2 and added 1 elements===");
    values.Remove(0);
    values.Remove(1);
    values.Remove(3);
    values.Add(2);
    Console.WriteLine(values.Contains(3));
    Console.WriteLine(values.Count());
}


static void TestStringValues()
{
    MyLinkedList<string> values = new MyLinkedList<string>();

    Console.WriteLine("===Case 1: Empty list===");
    Console.WriteLine(values.Contains("qwerty"));
    Console.WriteLine(values.Count());
    values.Remove("qwerty");

    Console.WriteLine("===Case 2: Added 3 elements===");
    values.Add("a");
    values.Add("b");
    values.Add("c");
    Console.WriteLine(values.Contains("a"));
    Console.WriteLine(values.Count());

    Console.WriteLine("===Case 3: Removed 2 and added 1 elements===");
    values.Remove("qwerty");
    values.Remove("a");
    values.Remove("c");
    values.Add("b");
    Console.WriteLine(values.Contains("c"));
    Console.WriteLine(values.Count());
}
