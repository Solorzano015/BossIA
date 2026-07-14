using IA26Online.Agents;
using UnityEngine;

namespace IA26Online.Decision.BehaviorTree.Actions
{
    // Deambular: jugador fuera del rango de detección (>Z)
    [CreateAssetMenu(
    fileName = "WanderAction",
    menuName = "Decision/BehaviourTree/Actions/WanderAction")]
    public class WanderAction : Task
    {
        

        public override bool Run(Boss boss)
        {
            boss.WanderBehaviour.GetSteering(); // KWander ya implementado en el proyecto
            return true;
        }
    }
}