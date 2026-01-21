using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProgram_Library
{
    public class User : Entity
    {
        private string _name = "";
        public string Name { get => _name; set => _name = value; }

        public User(string name) : base()
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"id:{Id}\nname:{Name}\ncreated:{CreatedAt}\nupdated:{UpdatedAt}";
        }
    }
}
