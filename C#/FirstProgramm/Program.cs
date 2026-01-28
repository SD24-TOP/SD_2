//using DataStructures.FormalLanguages;
//using DataStructures.FormalLanguages.Common;

//AutomataState state1 = new AutomataState("1");
//AutomataState state2 = new AutomataState("2");
//AutomataState state3 = new AutomataState("3");
////Автомат для языка {01,0101,010101...}
//FiniteAutomata finiteAutomata = new FiniteAutomata()
//{
//    Alphabet = { "0", "1" },
//    AutomataStates = [
//        state1,state2,state3
//    ],
//    Transitions = [
//        new Transition(state1,state2,"0"),
//        new Transition(state2,state3,"1"),
//        new Transition(state3,state2,"0"),
//        ],
//    StartState = state1,
//    EndStates = [state3],
//};

//Console.WriteLine("Тест 1. 01");
//Console.WriteLine(finiteAutomata.CheckString("01"));
//Console.WriteLine("Тест 2. 0101");
//Console.WriteLine(finiteAutomata.CheckString("0101"));
//Console.WriteLine("Тест 3. 0101010");
//Console.WriteLine(finiteAutomata.CheckString("0101010"));
//Console.WriteLine("Тест 4. 00");
//Console.WriteLine(finiteAutomata.CheckString("00"));

//LINQ
//pair.Value.ForEach(); //1,2,3,4 -> ForEache(c.WriteLine("1"))
//pair.Value.Select(); //1,2,3,4 -> Select(x=>x*x) -> 1,4,9,16
//pair.Value.Where(); // 1,2,3,4 -> Where(x=>x%2==0) -> 2,4
//pair.Value.Any(); //1,2,3,4 -> Any(x=>x%2==0) -> True
//pair.Value.All(); //1,2,3,4 -> All(x=>x%2==0) -> False

using DataStructures.Graph;

Graph graph1 = new Graph([
    [0,1,1,1],
    [1,0,1,1],
    [1,1,0,1],
    [1,1,1,0]
    ]);

Console.WriteLine(graph1.IsFull);
Console.WriteLine(graph1.IsOriented);
Console.WriteLine(graph1.IsWeighted);
Console.WriteLine(
    string.Join("\n",
        graph1.DestMatrix.Select(x =>
            string.Join(",", x)
        ).ToList()));

Console.WriteLine(string.Join("\n",
    graph1.ListOfLinks.Select(kv => $"{kv.Key}:{string.Join(",", kv.Value)}")
    ));


Vertex a = new Vertex("A");
Vertex b = new Vertex("B");
Vertex c = new Vertex("C");
Vertex d = new Vertex("D");


Graph graph2 = new Graph(new Dictionary<Vertex, List<Vertex>>()
    {
        { a, [ b, d ]},
        { b, [a]},
        { c, []},
        { d,  []}
    });

Console.WriteLine(graph2.IsFull);
Console.WriteLine(graph2.IsOriented);
Console.WriteLine(graph2.IsWeighted);
Console.WriteLine(
    string.Join("\n",
        graph2.DestMatrix.Select(x =>
            string.Join(",", x)
        ).ToList()));

Console.WriteLine(string.Join("\n",
    graph2.ListOfLinks.Select(kv=>$"{kv.Key}:{string.Join(",",kv.Value)}")
    ));