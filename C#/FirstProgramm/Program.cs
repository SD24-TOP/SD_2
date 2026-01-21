using DataStructures;
using DataStructures.OOP_basics;
using FirstProgram_Library;

Cat cat = new Cat("Meowut");
Console.WriteLine(cat.Name);
Console.WriteLine(cat.Roar());

cat.Name = "Pushok";
Console.WriteLine(cat.Name);
Console.WriteLine(cat.Roar());

List<Animal> animals = new List<Animal>();
animals.Add(cat);
animals.Add(new Dog("Bobik"));
animals.Add(new Parrot("Captain"));

foreach (var animal in animals)
{
    Console.WriteLine(animal.Roar());
}


User user1 = new User("Bob");
User user2 = new User("Tom");


Console.WriteLine(user1.ToString());
Console.WriteLine(user2.ToString());