using DataStructures.FormalLanguages;
using DataStructures.FormalLanguages.Common;

AutomataState state1 = new AutomataState("1");
AutomataState state2 = new AutomataState("2");
AutomataState state3 = new AutomataState("3");
//Автомат для языка {01,0101,010101...}
FiniteAutomata finiteAutomata = new FiniteAutomata()
{
    Alphabet = { "0", "1" },
    AutomataStates = [
        state1,state2,state3
    ],
    Transitions = [
        new Transition(state1,state2,"0"),
        new Transition(state2,state3,"1"),
        new Transition(state3,state2,"0"),
        ],
    StartState = state1,
    EndStates = [state3],
};

Console.WriteLine("\r\n//Автомат для языка {01,0101,010101...}");
Console.WriteLine("Тест 1. 01");
Console.WriteLine(finiteAutomata.CheckString("01"));
Console.WriteLine("Тест 2. 0101");
Console.WriteLine(finiteAutomata.CheckString("0101"));
Console.WriteLine("Тест 3. 0101010");
Console.WriteLine(finiteAutomata.CheckString("0101010"));
Console.WriteLine("Тест 4. 00");
Console.WriteLine(finiteAutomata.CheckString("00"));


state1 = new AutomataState("1");
state2 = new AutomataState("2");
state3 = new AutomataState("3");
AutomataState state4 = new AutomataState("4");
AutomataState state5 = new AutomataState("5");
AutomataState state6 = new AutomataState("6");

//Автомат для языка (ab)*c(ba)*a(b)*
FiniteAutomata finiteAutomata2 = new FiniteAutomata()
{
    Alphabet = { "a", "b", "c" },
    AutomataStates = [
        state1,state2,state3,
        state4,state5,state6
    ],
    Transitions = [
        new Transition(state1,state2,"a"),
        new Transition(state1,state4,"c"),
        new Transition(state2,state3,"b"),
        new Transition(state3,state2,"a"),
        new Transition(state3,state4,"c"),
        new Transition(state4,state5,"b"),
        new Transition(state5,state4,"a"),
        new Transition(state4,state6,"a"),
        new Transition(state6,state6,"b"),
        ],
    StartState = state1,
    EndStates = [state6],
};

Console.WriteLine("\r\n//Автомат для языка (ab)*c(ba)*a(b)*");
Console.WriteLine("Тест 1. ca");
Console.WriteLine(finiteAutomata2.CheckString("ca"));
Console.WriteLine("Тест 2. cbaa");
Console.WriteLine(finiteAutomata2.CheckString("cbaa"));
Console.WriteLine("Тест 3. ababcbababaa");
Console.WriteLine(finiteAutomata2.CheckString("ababcbababaa"));
Console.WriteLine("Тест 4. cbaabb");
Console.WriteLine(finiteAutomata2.CheckString("cbaabb"));
Console.WriteLine("Тест 5. aaa");
Console.WriteLine(finiteAutomata2.CheckString("aaa"));



//LINQ
//pair.Value.ForEach(); //1,2,3,4 -> ForEache(c.WriteLine("1"))
//pair.Value.Select(); //1,2,3,4 -> Select(x=>x*x) -> 1,4,9,16
//pair.Value.Where(); // 1,2,3,4 -> Where(x=>x%2==0) -> 2,4
//pair.Value.Any(); //1,2,3,4 -> Any(x=>x%2==0) -> True
//pair.Value.All(); //1,2,3,4 -> All(x=>x%2==0) -> False

//using DataStructures.Graph;

//Graph graph1 = new Graph([
//    [0,1,1,1],
//    [1,0,1,1],
//    [1,1,0,1],
//    [1,1,1,0]
//    ]);

//Console.WriteLine(graph1.IsFull);
//Console.WriteLine(graph1.IsOriented);
//Console.WriteLine(graph1.IsWeighted);
//Console.WriteLine(
//    string.Join("\n",
//        graph1.DestMatrix.Select(x =>
//            string.Join(",", x)
//        ).ToList()));

//Console.WriteLine(string.Join("\n",
//    graph1.ListOfLinks.Select(kv => $"{kv.Key}:{string.Join(",", kv.Value)}")
//    ));


//Vertex a = new Vertex("A");
//Vertex b = new Vertex("B");
//Vertex c = new Vertex("C");
//Vertex d = new Vertex("D");


//Graph graph2 = new Graph(new Dictionary<Vertex, List<Vertex>>()
//    {
//        { a, [ b, d ]},
//        { b, [a]},
//        { c, []},
//        { d,  []}
//    });

//Console.WriteLine(graph2.IsFull);
//Console.WriteLine(graph2.IsOriented);
//Console.WriteLine(graph2.IsWeighted);
//Console.WriteLine(
//    string.Join("\n",
//        graph2.DestMatrix.Select(x =>
//            string.Join(",", x)
//        ).ToList()));

//Console.WriteLine(string.Join("\n",
//    graph2.ListOfLinks.Select(kv=>$"{kv.Key}:{string.Join(",",kv.Value)}")
//    ));