using IA26Online.Agents;
using UnityEngine;

namespace IA26Online.Decision.BehaviorTree.Actions
{
    [CreateAssetMenu(
    fileName = "FleeAction",
    menuName = "Decision/BehaviourTree/Actions/FleeAction")]
    public class FleeAction : Task
    {
        

        public override bool Run(Boss boss)
        {
            // Se llama a Flee con SteeringBehaviour, ya implementado en el proyecto (KFlee)
            boss.FleeBehaviour.GetSteering();
            return true;
        }
    }
}