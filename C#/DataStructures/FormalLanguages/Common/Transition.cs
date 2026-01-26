namespace DataStructures.FormalLanguages.Common
{
    /// <summary>
    /// Переход конечного автомата
    /// </summary>
    /// <param name="from">Из какого состояния</param>
    /// <param name="to">В какое состояние</param>
    /// <param name="trigger">Символ, по которому осуществляется переход</param>
    public class Transition(
        AutomataState from,
        AutomataState to,
        string trigger)
    {
        /// <summary>
        /// Из какого состояния
        /// </summary>
        public AutomataState From { get; set; } = from;

        /// <summary>
        /// В какое состояния
        /// </summary>
        public AutomataState To { get; set; } = to;

        /// <summary>
        /// Символ, по которому осуществляется переход
        /// </summary>
        public string Trigger { get; set; } = trigger;
    }
}