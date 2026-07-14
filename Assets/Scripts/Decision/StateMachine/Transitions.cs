using UnityEngine;

namespace IA26Online.Decision.StateMachine
{
    public class Transitions
    {
        public Action[] actions = new Action[0];
        public State objective_state;
        public Condition condition;

        public bool IsTriggered()
        {
            if (condition != null && condition.Test() == true)
                return true;
            return false;
        }
    }
}

