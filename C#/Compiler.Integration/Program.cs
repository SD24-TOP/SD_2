using Compiler.Lib;
/*
 * 
 * 
 *  Minimal program: 
    Var a - Declaration 1
    a = 5 - Equation 1
    Print a - Print 1
 */

// Read
string path = "code.txt";
Reader reader = new Reader(path);
await reader.Read();
LexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzer();
Console.WriteLine(
    lexicalAnalyzer.CheckLexems(reader.Code) ? 
    "Лексический анализ пройден успешно" : 
    "Лексический анализ завершился с ошибкой");

Console.WriteLine(string.Join(',',lexicalAnalyzer.Lexems));


// Lexems

// Syntax

// Generation


