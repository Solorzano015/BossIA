using IA26Online.Agents;

namespace IA26Online.Decision.BehaviorTree.Actions
{
    // Deambular: jugador fuera del rango de detección (>Z)
    public class WanderAction : Task
    {
        private Boss boss;

        public WanderAction(Boss boss)
        {
            this.boss = boss;
        }

        public override bool Run()
        {
            boss.WanderBehaviour.GetSteering(); // KWander ya implementado en el proyecto
            return true;
        }
    }
}