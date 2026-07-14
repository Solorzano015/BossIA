using UnityEngine;

namespace IA26Online.Decision.StateMachine.Actions
{
    public class APursue : Action
    {
        private BossController boss; //POR HACER EL BOSS CONTROLLER

        public APursue(BossController boss)
        {
            this.boss = boss;
        }
        public override void Execute()
        {
            boss.steering = boss.pursue.GetSteering;
        }
    }
}
