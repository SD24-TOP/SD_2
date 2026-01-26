using DataStructures.FormalLanguages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.FormalLanguages
{
    public class FiniteAutomata
    {
        #region Properties
        /// <summary>
        /// Алфавит символов
        /// </summary>
        public List<string> Alphabet { get; set; } = [];

        /// <summary>
        /// Состояния автомата
        /// </summary>
        public List<AutomataState> AutomataStates { get; set; } = [];

        /// <summary>
        /// Начальное состояние
        /// </summary>
        public required AutomataState StartState { get; set; }

        /// <summary>
        /// Начальное состояние
        /// </summary>
        public required List<AutomataState> EndStates { get; set; }

        /// <summary>
        /// Функция переходов
        /// </summary>
        public List<Transition> Transitions { get; set; } = [];
        #endregion

        #region Methods
        /// <summary>
        /// Проверить цепочку на принадлежность языку
        /// </summary>
        /// <param name="check">Цепочка для проверки</param>
        /// <returns>true, если цепочка принадлежит языку</returns>
        public bool CheckString(string check)
        {
            //1. Инициализация состояний, стартовое состояние
            AutomataState currentState = StartState;
            int index = 0;
            char currentChar = check[index];
            AutomataState? nextState = GetTransition(currentChar, currentState);
            //2. Посимвольно читать цепочку и выполнять доступные функции перехода
            while (nextState != null && index < check.Length-1)
            {
                currentState = nextState;
                index++;
                currentChar = check[index];
                nextState = GetTransition(currentChar, currentState);
            }

            currentState = nextState;
            //3. Если строка прочитана не полностью или тек. состояние не
            //   финальное, то возвращаем false,
            //   иначе true - цепочка приналдежит языку

            if (index < check.Length - 1) return false;
            if (EndStates.Contains(currentState))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// Проверить существует ли переход по символу из состояния
        /// </summary>
        /// <param name="currentChar">символ</param>
        /// <param name="currentState">состояние</param>
        /// <returns>состояние, куда можно перейти</returns>
        private AutomataState? GetTransition(char currentChar, AutomataState currentState)
        {
            foreach (var transition in Transitions)
            {
                if(transition.From == currentState && transition.Trigger == Convert.ToString(currentChar))
                {
                    return transition.To;
                }
            }
            return null;
        }
    }
}
