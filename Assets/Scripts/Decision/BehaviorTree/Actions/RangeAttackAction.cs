using UnityEngine;
using IA26Online.Agents;

namespace IA26Online.Decision.BehaviorTree.Actions
{
    // Ataque a distancia
    public class RangeAttackAction : Task
    {
        private Boss boss;

        public RangeAttackAction(Boss boss)
        {
            this.boss = boss;
        }

        public override bool Run()
        {
            float distance = Vector3.Distance(boss.transform.position, boss.Player.position);

            if (distance > boss.RangedAttackRange)
                return false; // por si acaso: fuera de rango de ataque a distancia

            // ... lógica del ataque a distancia que queramos implementar (proyectil, cooldown, etc.)
            return true;
        }
    }
}