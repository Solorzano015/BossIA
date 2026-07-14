using IA26Online.Agents;

namespace IA26Online.Decision.BehaviorTree.Actions
{
    // Perseguir: distancia entre Y (rango de ataque a distancia) y Z (rango de detección)
    public class PursueAction : Task
    {
        private Boss boss;

        public PursueAction(Boss boss)
        {
            this.boss = boss;
        }

        public override bool Run()
        {
            boss.PursueBehaviour.GetSteering(); // se llama a Pursue con SteeringBehaviour (KPursue)
            return true;
        }
    }
}