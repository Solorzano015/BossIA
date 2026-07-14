using IA26Online.Agents;
using UnityEngine;

namespace IA26Online.Decision.BehaviorTree.Actions
{
    // Contraataque C a C: se dispara si tras el ataque el jugador sigue cerca (Sigue Cerca)
    [CreateAssetMenu(
    fileName = "CounterAttackAction",
    menuName = "Decision/BehaviorTree/Actions/CounterAttackAction")]
    public class CounterAttackAction : Task
    {
        private Boss boss;

        public CounterAttackAction(Boss boss)
        {
            this.boss = boss;
        }

        public override bool Run()
        {
            // ... lógica del contraataque (daño extra, animación específica)
            return true;
        }
    }
}