using UnityEngine;

namespace IA26Online.Decision.StateMachine.Actions
{
    public class AIncreaseSpeed : Action
    {
        private BossController boss; //POR HACER EL BOSS CONTROLLER

        public AIncreaseSpeed(BossController boss)
        {
            this.boss = boss;
        }
        public override void Execute()
        {
            boss.steering = boss.IncreaseSpeed();
        }
    }
}
