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
        private Boss boss;

        public HealthBelow25(Boss boss) // constructor para la clase que no puede instanciar
        {
            this.boss = boss;
        }

        public override bool Run()
        {
            return boss.Health < 25f;
            
        }
    }
}