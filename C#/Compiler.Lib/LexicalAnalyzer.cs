

namespace Compiler.Lib
{
    public class LexicalAnalyzer
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz1234567890";
        public List<Lexem> Lexems { get; set; } = [];
        public bool CheckLexems(List<string> code)
        {
            foreach (string line in code)
            {
                foreach (string line2 in line.Split(" "))
                {
                    switch (line2)
                    {
                        case "Var":
                            Lexems.Add(Lexem.Var);
                            break;
                        case "Int":
                            Lexems.Add(Lexem.Int);
                            break;
                        case "String":
                            Lexems.Add(Lexem.String);
                            break;
                        case "+":
                            Lexems.Add(Lexem.Plus);
                            break;
                        case "=":
                            Lexems.Add(Lexem.Equal);
                            break;
                        case "Print":
                            Lexems.Add(Lexem.Print);
                            break;
                        default:
                            List<string> variables = line2.Split(",").ToList();
                            foreach (var variable in variables)
                            {
                                foreach (char symbol in variable)
                                {
                                    if (!alphabet.Contains(symbol)) { return false; }
                                }
                                Lexems.Add(Lexem.Identifier);
                            }
                            break;
                    }
                }
            }
            return true;
        }
    }
}
