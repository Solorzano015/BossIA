using System;
//using UnityEditorInternal;
using IA26Online.Decision.StateMachine;
using UnityEngine;

namespace IA26Online.Decision.StateMachine
{
    public class State
    {
        //acciones_estado : Action[]
        public Action[] actions_state = new Action[0];
        //acciones_entrada : Action[]
        public Action[] actions_entry = new Action[0];
        //acciones_salida : Action[]
        public Action[] actions_exit = new Action[0];
        //transiciones : Transition[]
        public Transitions[] transitions = new Transitions[0]; //ESTO LO COMENTE (ISA)

        //estado_padre : State
        public State root_state;

        //State[] GetHierarchy()
        public State[] GetHierarchy()
        {
            int i = 0;
            int j = 0;

            //el estado_actual es este mismo estado
            State current_state = this;           
            while (current_state != null)
            {
                i++;
                current_state = current_state.root_state;
            }

            //mientras el estado_actual sea distinto de nulo, agregar el estado_actual a la lista
            State[] hierarchy = new State[i];
            current_state = this;       
            while(current_state != null)
            {
                hierarchy[j++] = current_state;
                j++;
                current_state = current_state.root_state;
                //sustituir el estado_actual por el padre del estado_actual
            }
            //devolver la lista, invirtiendo el orden
            System.Array.Reverse(hierarchy);
            return hierarchy;
        }

        public int GetPhase()
        {
            int phase = 0;
            //el estado_actual es este mismo estado
            State present_state = this;

            //mientras el estado_actual sea distinto de nulo
            while (present_state != null)
            {
                //contador += 1
                phase++;

                //sustituir el estado_actual por el padre del estado_actual
                present_state = present_state.root_state;
            }
            //devolver el contador
            return phase;
        }
    }
}
