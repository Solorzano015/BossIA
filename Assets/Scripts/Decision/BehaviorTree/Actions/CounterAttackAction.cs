using IA26Online.Agents;

namespace IA26Online.Decision.BehaviorTree.Actions
{
    // Contraataque C a C: se dispara si tras el ataque el jugador sigue cerca (Sigue Cerca)
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