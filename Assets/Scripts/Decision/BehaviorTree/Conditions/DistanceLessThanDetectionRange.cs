using UnityEngine;
using IA26Online.Agents;

namespace IA26Online.Decision.BehaviorTree.Conditions
{
    // <Z : el jugador está dentro del rango de detección del jefe
    [CreateAssetMenu(fileName = "CanBeDetected", menuName = "Decision/BehaviourTree/Conditions/DistanceLessThanDetectionRange")]

    public class DistanceLessThanDetectionRange : Task
    {
        private Boss boss;

        public DistanceLessThanDetectionRange(Boss boss)
        {
            this.boss = boss;
        }

        public override bool Run()
        {
            float distance = Vector3.Distance(boss.transform.position, boss.Player.position);
            return distance < boss.DetectionRange;
        }
    }
}