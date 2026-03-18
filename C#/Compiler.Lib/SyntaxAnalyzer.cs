using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Compiler.Lib
{
    public class SyntaxAnalyzer
    {
        public SyntaxAnalyzer(List<Lexem> lexems, Dictionary<string, DataType> nameTable, List<string> code)
        {
            Lexems = lexems;
            NameTable = nameTable;
            CodeGenerator = new CodeGenerator();
            Code = code;
        }

        public CodeGenerator CodeGenerator { get; set; }
        public List<Lexem> Lexems { get; }
        public Dictionary<string, DataType> NameTable { get; set; }

        public List<string> Code { get; set; }

        public bool Parse()
        {
            int idx = 0;
            idx = ParseVariableDeclaration(idx);
            idx = ParseExpressions(idx);
            idx = ParsePrint(idx);
            return idx == Lexems.Count;
        }

        private int ParseVariableDeclaration(int idx)
        {
            while (Lexems[idx] != Lexem.Expressions)
            {
                if (Lexems[idx] == Lexem.Name)
                {
                    string name = Code[0].Split(",")[idx];
                    DataType type = NameTable[name];
                    CodeGenerator.GenerateVariable(name, type);
                }
                idx++;
            }
            return idx++;
        }
        private int ParseExpressions(int idx)
        {
            while (Lexems[idx] != Lexem.Print)
            {
                if(Lexems[idx] == Lexem.Name)
                {
                    if (Lexems[idx++] == Lexem.Equal)
                    {
                        idx = ParseExpression(idx);
                    }
                }
                idx++;
            }
            return idx++;
        }

        private int ParseExpression(int idx)
        {
            // Сравнения
            // -> логические операции(импликация,дизъюнкция,конъюнкция)
            // -> арифметические операции(Сумма или разность, Умножение или деление или остаток от деления)
            // -> унарные операции

            // (2+3*5)>(3+2) ->bool
            return idx;
        }

        private int ParsePrint(int idx)
        {
            string name = Code.Last().Split(",")[idx];
            CodeGenerator.GeneratePrint(name);
            return idx++;
        }
    }
}
