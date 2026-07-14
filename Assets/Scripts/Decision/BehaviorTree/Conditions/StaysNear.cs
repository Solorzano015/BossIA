using UnityEngine;
using IA26Online.Agents;

namespace IA26Online.Decision.BehaviorTree.Conditions
{
    // ?Sigue Cerca -> se evalúa justo después de "Ataque C a C" para decidir si el jugador
    // sigue dentro del rango de melee y así disparar el comportamiento reactivo (contraataque)
    public class StaysNear : Task
    {
        private Boss boss;

        public StaysNear(Boss boss)
        {
            this.boss = boss;
        }

        public override bool Run()
        {
            float distance = Vector3.Distance(boss.transform.position, boss.Player.position);
            return distance < boss.AttackRange;
        }
    }
}