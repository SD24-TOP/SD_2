namespace DataStructures.FormalLanguages.Common
{
    /// <summary>
    /// Состояние конечного автомата
    /// </summary>
    /// <param name="name">Название состояния</param>
    public class AutomataState(string name)
    {
        /// <summary>
        /// Название состояния
        /// </summary>
        public string Name { get; set; } = name;
    }
}