namespace DataStructures.OOP_basics
{
    public class Parrot : Animal
    {
        public Parrot(string name) : base(name)
        {
        }

        #region Methods
        public override string Roar()
        {
            return $"{Name} says words!";
        }
        #endregion
    }
}
