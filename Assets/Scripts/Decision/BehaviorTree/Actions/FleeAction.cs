using IA26Online.Agents;
using UnityEngine;

namespace IA26Online.Decision.BehaviorTree.Actions
{
    [CreateAssetMenu(
    fileName = "FleeAction",
    menuName = "Decision/BehaviourTree/Actions/FleeAction")]
    public class FleeAction : Task
    {
        private Boss boss;

        public FleeAction(Boss boss) // si se quiere llamar desde boss
        {
            this.boss = boss;
        }

        public override bool Run()
        {
            // Se llama a Flee con SteeringBehaviour, ya implementado en el proyecto (KFlee)
            boss.FleeBehaviour.GetSteering();
            return true;
        }
    }
}