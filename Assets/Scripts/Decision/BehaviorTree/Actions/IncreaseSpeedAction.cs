using IA26Online.Agents;
using UnityEngine;

namespace IA26Online.Decision.BehaviorTree.Actions
{
    // Aumentar velocidad con vida < 50%
    [CreateAssetMenu(
    fileName = "IncreaseSpeedAction",
    menuName = "Decision/BehaviourTree/Actions/IncreaseSpeedAction")]
    public class IncreaseSpeedAction : Task
    {
        

        public override bool Run(Boss boss)
        {
            boss.EnterPhase2();
            return true;
        }
    }
}