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

Console.WriteLine("Тест 1. 01");
Console.WriteLine(finiteAutomata.CheckString("01"));
Console.WriteLine("Тест 2. 0101");
Console.WriteLine(finiteAutomata.CheckString("0101"));
Console.WriteLine("Тест 3. 0101010");
Console.WriteLine(finiteAutomata.CheckString("0101010"));
Console.WriteLine("Тест 4. 00");
Console.WriteLine(finiteAutomata.CheckString("00"));