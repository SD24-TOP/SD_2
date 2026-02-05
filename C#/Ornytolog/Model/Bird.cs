using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornytolog.Model
{
    public class Bird(Guid? id = null,string name ="Bird")
    {
        public Guid? Id { get; set; } = id;
        public string Name { get; set; } = name;

        public override string ToString() => $"Name: {name}; Id: {id}";
        public override bool Equals(object? obj)
        {
            if (this == null && obj == null) return true;
            if(obj == null) return false;
            return this.Id == ((Bird)obj).Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
