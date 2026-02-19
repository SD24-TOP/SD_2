

namespace Compiler.Lib
{
    public class LexicalAnalyzer
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz1234567890";
        public List<Lexem> Lexems { get; set; } = [];
        public bool CheckLexems(List<string> code)
        {
            foreach (string line in code) {
                foreach (string line2 in line.Split(" ")) {
                    switch (line2)
                    {
                        case "Var":
                            Lexems.Add(Lexem.Var);
                            break;

                        case "=":
                            Lexems.Add(Lexem.Equal);
                            break;

                        case "Print":
                            Lexems.Add(Lexem.Print);
                            break;

                        default:
                            if (alphabet.Contains(line2)) {
                                Lexems.Add(Lexem.Identifier);
                            }
                            else { return false; }
                                break;
                    }
                }
            }
            return true;
        }
    }
}
