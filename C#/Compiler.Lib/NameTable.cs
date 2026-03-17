using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Lib
{
    public class NameTable
    {
        public Dictionary<string, DataType> Table { get; set; } = [];

        // Тип1 П1,П2,П3 Тип2 П4,П5,П6
        public void Fill(string v)
        {
            List<string> divided = v.Split(' ').ToList();
            DataType currentType = DataType.Int;
            bool evenIndex = true;
            foreach (var item in divided)
            {
                if (evenIndex)
                {
                    bool isDataType = Enum.TryParse(item, false, out currentType);
                    if (isDataType)
                    {
                        Console.WriteLine($"Получен тип данных {currentType}");
                    }
                    else {
                        Console.WriteLine($"Указан неверный тип данных {item}");
                        return; 
                    }
                    evenIndex= false;
                }
                else
                {
                    List<string> variables = item.Split(",").ToList();
                    foreach (var variable in variables)
                    {
                        Table[variable] = currentType;
                    }
                    evenIndex = true;
                }
            }

        }
    }
}
