using NUnit.Framework;
using UnityEngine;
using UnityEngine.Profiling;

namespace IA26Online.Decision.StateMachine
{
    public class HierarchicalSM : StateMachine
    {
        public HierarchicalSM(State initialState) : base(initialState)
        {
        }

        public override Action[] Update()
        {
            //si el estado_actual es nulo, no devolver nada
            if (current_state == null)
            {
                return null;
            }

            //a jerarquía es una lista de estados = estado_actual.GetHierarchy()
            State[] hierarchy = current_state.GetHierarchy();

            //se crea un objeto mejor_transición = new Transition()
            Transitions best_transition = null;

            //también se necesita un número entero mejor_nivel = infinito
            int best_phase = int.MaxValue;

            foreach (State state in hierarchy) //por cada estado en la jerarquía
            {
                //por cada transición en la lista de transiciones del estado
                foreach (Transitions transition in state.transitions)
                {
                    if (transition.IsTriggered() == true) //si la transición ha sido provocada
                    {
                        //si el nivel del estado es menor que el mejor_nivel
                        if (state.GetPhase() < best_phase == true)
                        {
                            //sustituir el valor del mejor_nivel por el nivel del estado
                            best_phase = state.GetPhase();
                            //guardar la transición como la mejor_transición
                            best_transition = transition;
                        }
                    }
                }
            }
            //si la mejor_transición no es nula, return ApplyTransition(mejor_transición)
            if (best_transition != null)
                return ApplyTransition(best_transition);
            return current_state.actions_state;
        }

        //Action[] ApplyTransition(mejor_transición)
        protected virtual Action[] ApplyTransition(Transitions best_transition)
        {
            //la jerarquía_origen es una lista de estados = estado_actual.GetHierarchy()
            State[] root_hierarchy = current_state.GetHierarchy();
            //la jerarquía_destino es una lista de estados = mejor_transición.estado_objetivo.GetHierarchy()
            State[] target_hierarchy = best_transition.objective_state.GetHierarchy();

            //recorrer ambas jerarquías simultáneamente para encontrar el ancestro_común
            int index_comm_anc = -1;

            int minLength = root_hierarchy.Length;
            if (target_hierarchy.Length < minLength == true)
                minLength = target_hierarchy.Length;

            for (int i = 0; i < minLength; i++)
            {
                if (root_hierarchy[i] == target_hierarchy[i])
                    index_comm_anc = i;
                else
                    break;
            }

            int totalActions = 0;

            for (int i = root_hierarchy.Length - 1; i > index_comm_anc; i--)
                totalActions += root_hierarchy[i].actions_exit.Length;

            totalActions += best_transition.actions.Length;

            for (int i = index_comm_anc + 1; i < target_hierarchy.Length; i++)
                totalActions += target_hierarchy[i].actions_entry.Length;

            //las acciones son una lista de objetos del tipo Action
            Action[] actions = new Action[totalActions];
            int index = 0;

            //desde el final de la jerarquía_origen hasta alcanzar el ancestro_común, 
            for (int i = root_hierarchy.Length - 1; i > index_comm_anc; i--)
            {
                //por cada estado acciones += acciones de salida del estado
                foreach (Action action in root_hierarchy[i].actions_exit)
                {                   
                    actions[index] = action;
                    index++;
                }
            }

            foreach (Action action in best_transition.actions)
            {
                actions[index] = action;
                index++;
            }

            for (int i = index_comm_anc + 1; i < target_hierarchy.Length; i++)
            {
                foreach (Action action in target_hierarchy[i].actions_entry)
                {
                    actions[index] = action;
                    index++;
                }
            }

            //estado_actual = estado objetivo de la mejor_transición
            current_state = best_transition.objective_state;
            //devolver las acciones
            return actions;
        }
    }
}