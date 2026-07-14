using IA26Online.Agents;
using UnityEngine;

namespace IA26Online.Decision.BehaviorTree.Actions
{
    // Perseguir: distancia entre Y (rango de ataque a distancia) y Z (rango de detección)
    [CreateAssetMenu(
    fileName = "PursueAction",
    menuName = "Decision/BehaviourTree/Actions/PursueAction")]
    public class PursueAction : Task
    {
        

        public override bool Run(Boss boss)
        {
            boss.PursueBehaviour.GetSteering(); // se llama a Pursue con SteeringBehaviour (KPursue)
            return true;
        }
    }
}