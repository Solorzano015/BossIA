using UnityEngine;
using IA26Online.Agents;

namespace IA26Online.Decision.BehaviorTree.Conditions
{
    // >Z : Jugador demasiado lejos para ser detectado
    [CreateAssetMenu(fileName = "TooFarToDetect", menuName = "Decision/BehaviourTree/Conditions/DistanceGreaterThanDetectionRange")]
    public class DistanceGreaterThanDetectionRange : Task
    {
        private Boss boss;

        public DistanceGreaterThanDetectionRange(Boss boss)
        {
            this.boss = boss;
        }

        public override bool Run()
        {
            float distance = Vector3.Distance(boss.transform.position, boss.Player.position);
            return distance > boss.DetectionRange;
        }
    }
}