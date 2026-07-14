using IA26Online.Decision.StateMachine;
using UnityEngine;

namespace IA26Online.Decision.StateMachine
{
    public class AndCondition : Condition
    {
        //condición_A : Condition
        private Condition condition_a;
        //condición_B : Condition
        private Condition condition_b;

        //constructor para poder inicializar
        public AndCondition(Condition a, Condition b)
        {
            condition_a = a;
            condition_b = b;
        }

        //bool Test()
        //{
        //    return condición_A.Test() & condición_B.Test()
        //}
        public override bool Test()
        {
            if (condition_a.Test() == true && condition_b.Test() == true)
                return true;
            return false;
        }
    }
}
