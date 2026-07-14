using UnityEngine;

namespace IA26Online.Decision.StateMachine.Actions
{
    public class AExplode : Action
    {
        private BossController boss; //POR HACER EL BOSS CONTROLLER

        public AExplode(BossController boss)
        {
            this.boss = boss;
        }
        public override void Execute()
        {
            boss.Die();
        }
    }
}