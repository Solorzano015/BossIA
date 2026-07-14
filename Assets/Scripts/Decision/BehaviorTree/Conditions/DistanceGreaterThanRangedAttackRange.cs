using UnityEngine;
using IA26Online.Agents;

namespace IA26Online.Decision.BehaviorTree.Conditions
{
    // >Y : la distancia al jugador es mayor que el rango de ataque a distancia
    [CreateAssetMenu(fileName = "tooFarToDistanceAttack", menuName = "Decision/BehaviourTree/Conditions/DistanceGreaterThanRangedAttackRange")]

    public class DistanceGreaterThanRangedAttackRange : Task
    {
        

        public override bool Run(Boss boss)
        {
            float distance = Vector3.Distance(boss.transform.position, boss.Player.position);
            return distance > boss.RangedAttackRange;
        }
    }
}