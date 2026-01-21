using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.OOP_basics
{
    public abstract class Animal
    {
        #region Fields
        private string _name;
        #endregion

        #region Properties
        public string Name { get; set; }
        #endregion

        #region Constructor
        public Animal(string name)
        {
            Name = name;
        }
        #endregion

        #region Methods
        public virtual string Roar()
        {
            return $"{Name} says something!";
        }
        #endregion
    }
}
