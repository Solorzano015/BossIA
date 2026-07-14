using IA26Online.Agents;

namespace IA26Online.Decision.BehaviorTree.Conditions
{
    // Vida < 25%
    public class HealthBelow25 : Task
    {
        private Boss boss;

        public HealthBelow25(Boss boss) // constructor para la clase que no puede instanciar
        {
            this.boss = boss;
        }

        public override bool Run()
        {
            return boss.Health < 25f;
        }
    }
}