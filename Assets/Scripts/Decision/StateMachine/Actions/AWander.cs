using UnityEngine;

namespace IA26Online.Decision.StateMachine.Actions
{
    public class AWander : Action
    {
        private BossController boss; //POR HACER EL BOSS CONTROLLER

        public AWander(BossController boss)
        {
            this.boss = boss;
        }
        public override void Execute()
        {
            boss.steering = boss.wander.GetSteering;
        }
    }
}
    
