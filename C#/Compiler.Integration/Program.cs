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

NameTable nameTable = new NameTable();
//Проверка на первую строку - Тип данных a,b,c и т.д.
nameTable.Fill(reader.Code[0]);

Console.WriteLine(nameTable.Table.Count > 0?
    string.Join("\n",
        nameTable.Table.ToList()
        .Select(x => $"{x.Key}:{x.Value}")
    ):"Ошибка обьявления переменных");

Console.WriteLine(string.Join(',',lexicalAnalyzer.Lexems));


// Lexems

// Syntax

// Generation


