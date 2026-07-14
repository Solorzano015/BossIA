using UnityEngine;

namespace IA26Online.Decision.StateMachine.Actions
{
    public class AFlee : Action
    {
        private BossController boss; //POR HACER EL BOSS CONTROLLER

        public AFlee(BossController boss)
        {
            this.boss = boss;
        }
        public override void Execute()
        {
            boss.steering = boss.flee.GetSteering();
        }
    }
}