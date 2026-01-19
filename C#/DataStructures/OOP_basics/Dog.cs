namespace DataStructures.OOP_basics
{
    public class Dog : Animal
    {
        public Dog(string name) : base(name)
        {
        }

        #region Methods
        public override string Roar()
        {
            return $"{Name} says woof!";
        }
        #endregion
    }
}
