using System;
using UnityEditorInternal;
using UnityEngine;

namespace IA26Online.Decision.StateMachine
{
    public class State : MonoBehaviour
    {
        //acciones_estado : Action[]
        public Action[] actions_state = new Action[0];
        //acciones_entrada : Action[]
        public Action[] actions_entry = new Action[0];
        //acciones_salida : Action[]
        public Action[] actions_exit = new Action[0];
        //transiciones : Transition[]
        //public Action[] transitions = new Transition[0]; //ESTO LO COMENTE ISA

        //estado_padre : State
        public State root_state;

        public State[] GetHierarchy()
        {
            int i = 0;
            int j = 0;

            State current_state = this;
            while (current_state != null)
            {
                i++;
                current_state = current_state.root_state;
            }

            State[] hierarchy = new State[i];
            current_state = this;       
            while(current_state != null)
            {
                hierarchy[j++] = current_state;
                j++;
                current_state = current_state.root_state;
            }
            System.Array.Reverse(hierarchy);
            return hierarchy;
        }

        public int GetPhase()
        {
            int phase = 0;
            State present_state = this;
            while (present_state != null)
            {
                phase++;
                present_state = present_state.root_state;
            }
            return phase;
        }
    }
}
