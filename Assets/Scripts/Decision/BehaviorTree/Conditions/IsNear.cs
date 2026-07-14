using UnityEngine;
using IA26Online.Agents;
using System.IO.Enumeration;

namespace IA26Online.Decision.BehaviorTree.Conditions
{
    [CreateAssetMenu(
    fileName = "IsNear",
    menuName = "Decision/BehaviourTree/Conditions/IsNear")]
    public class IsNear : Task
    {
        

        public override bool Run(Boss boss)
        {
            float distance = Vector3.Distance(boss.transform.position, boss.Player.position);
            return distance < boss.AttackRange; // Si es menor que el attackRange devolverá true, si no False
        }
    }
}