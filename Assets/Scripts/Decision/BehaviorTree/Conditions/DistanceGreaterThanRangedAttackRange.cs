using UnityEngine;
using IA26Online.Agents;

namespace IA26Online.Decision.BehaviorTree.Conditions
{
    // >Y : la distancia al jugador es mayor que el rango de ataque a distancia
    [CreateAssetMenu(fileName = "tooFarToDistanceAttack", menuName = "Decision/BehaviourTree/Conditions/DistanceGreaterThanDetectionRange")]

    public class DistanceGreaterThanRangedAttackRange : Task
    {
        private Boss boss;

        public DistanceGreaterThanRangedAttackRange(Boss boss)
        {
            this.boss = boss;
        }

        public override bool Run()
        {
            float distance = Vector3.Distance(boss.transform.position, boss.Player.position);
            return distance > boss.RangedAttackRange;
        }
    }
}