using System;
using UnityEngine;

namespace IA26Online.Decision.StateMachine
{
    public class StateMachine
    {
        //estado_inicial : State
        protected State root_state;
        //estado_actual : State = estado_inicial
        protected State current_state;

        public State CurrentState => current_state;

        public StateMachine(State initialState)
        {
            root_state = initialState;
            current_state = root_state;
        }

        public virtual Action[] Update()
        {
            //se crea un objeto triggered = new Transition()
            Transitions triggered = null;

            //por cada transición en la lista de transiciones del estado_actual
            foreach (Transitions transition in current_state.transitions)
            {
                //si la transición ha sido provocada, triggered = transición
                if (transition.IsTriggered() == true)
                {
                    triggered = transition;
                    break;
                }
            }

            //si la transición triggered se trata de un objeto nulo, devolver las acciones de estado del estado_actual
            if (triggered == null)
            {
                return current_state.actions_state;
            }

            //si no, el estado_futuro es el estado objetivo de triggered
            State future_state = triggered.objective_state;

            int totalActions = current_state.actions_exit.Length
                + triggered.actions.Length
                + future_state.actions_entry.Length;

            //las acciones son una lista de objetos del tipo Action
            Action[] actions = new Action[totalActions];
            int index = 0;

            //acciones = acciones de salida del estado_actual
            foreach (Action action in current_state.actions_exit)
            {
                actions[index] = action;
                index++;
            }

            //acciones += acciones de la transición triggered
            foreach (Action action in triggered.actions)
            {
                actions[index] = action;
                index++;
            }

            //acciones += acciones de entrada del estado_futuro
            foreach (Action action in future_state.actions_entry)
            {
                actions[index] = action;
                index++;
            }

            //estado_actual = estado_futuro
            current_state = future_state;
            return actions;
        }
    }
}
