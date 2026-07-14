using IA26Online.Agents;

namespace IA26Online.Decision.BehaviorTree.Actions
{
    // Aumentar velocidad con vida < 50%
    public class IncreaseSpeedAction : Task
    {
        private Boss boss;

        public IncreaseSpeedAction(Boss boss)
        {
            this.boss = boss;
        }

        public override bool Run()
        {
            boss.EnterPhase2();
            return true;
        }
    }
}