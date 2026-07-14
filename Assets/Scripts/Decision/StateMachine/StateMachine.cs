using System;
using UnityEngine;

namespace IA26Online.Decision.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        protected State root_state;
        protected State current_state;

        public State CurrentState => current_state;

        public StateMachine(State initialState)
        {
            root_state = initialState;
            current_state = root_state;
        }
        /* ESTO LO COMENTE YO ISA
        public virtual Action[] Update()
        {

        }
        */
    }
}

