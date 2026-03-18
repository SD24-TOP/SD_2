

namespace Compiler.Lib
{
    public class LexicalAnalyzer
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz1234567890";

        public LexicalAnalyzer(Dictionary<string, DataType> table)
        {
            NameTable = table;
        }

        public List<Lexem> Lexems { get; set; } = [];
        public Dictionary<string, DataType> NameTable { get; }

        public bool CheckLexems(List<string> code)
        {
            for (int i = 0; i < code.Count; i++)
            {
                string line = code[i];
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
                                if (NameTable.Keys.Contains(variable))
                                {
                                    Lexems.Add(Lexem.Name);
                                }
                                else
                                {
                                    char symbol = variable[0];
                                    if (char.IsDigit(symbol))
                                    {
                                        Lexems.Add(Lexem.Int_val);
                                    }
                                    else if (symbol=='\"' && variable.Last() == '\"')
                                    {
                                        Lexems.Add(Lexem.String_val);
                                    }
                                }
                            }
                            break;
                    }
                }
                if (i == 0)
                {
                    Lexems.Add(Lexem.Expressions);
                }
                else if(i<code.Count-2)
                {
                    Lexems.Add(Lexem.NextExpr);
                }
            }
            return true;
        }
    }
}
