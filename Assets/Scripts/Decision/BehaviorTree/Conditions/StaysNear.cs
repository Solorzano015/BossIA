using UnityEngine;
using IA26Online.Agents;

namespace IA26Online.Decision.BehaviorTree.Conditions
{
    // ?Sigue Cerca -> se evalúa justo después de "Ataque C a C" para decidir si el jugador
    // sigue dentro del rango de melee y así disparar el comportamiento reactivo (contraataque)
    [CreateAssetMenu(
    fileName = "StaysNear",
    menuName = "Decision/BehaviourTree/Conditions/StaysNear")]
    public class StaysNear : Task
    {
        

        public override bool Run(Boss boss)
        {
            float distance = Vector3.Distance(boss.transform.position, boss.Player.position);
            return distance < boss.AttackRange;
        }
    }
}