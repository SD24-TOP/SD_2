using DataStructures.List;

// Case 1: Empty list
MyLinkedList values = new MyLinkedList();

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
Console.WriteLine(values.Contains(2));
Console.WriteLine(values.Count());
