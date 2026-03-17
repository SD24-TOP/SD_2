using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Lib
{
    public class Reader(string path = "code.txt")
    {
        public string Path { get; set; } = path;
        public List<string> Code { get; set; } = [];

        public async Task Read()
        {
            string text;
            using (StreamReader reader = new StreamReader(path))
            {
                text = await reader.ReadToEndAsync();
                Code = text.Split("\r\n").ToList().Select(x=>x.Trim()).ToList();
                Console.WriteLine("Код прочитан успешно.");
            }

            const int MIN_LENGTH = 3;
            if (Code.Count < MIN_LENGTH)
            {
                Console.WriteLine("Некорректная структура программы");
                return;
            }
        }
    }
}
