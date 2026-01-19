namespace DataStructures.OOP_basics
{
    public class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
        }

        #region Methods
        public override string Roar()
        {
            return $"{Name} says meow!";
        }
        #endregion
    }
}
