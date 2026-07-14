using IA26Online.Agents;
using System.Diagnostics;
using UnityEngine;

namespace IA26Online.Decision.BehaviorTree.Conditions
{
    // Vida < 25
    [CreateAssetMenu(
    fileName = "HealthBelow25",
    menuName = "Decision/BehaviourTree/BossIA/HealthBelow25")]
    public class HealthBelow25 : Task
    {
        

        public override bool Run(Boss boss)
        {
            return boss.Health < 25f;
            
        }
    }
}