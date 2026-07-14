using UnityEngine;

namespace IA26Online.Decision.StateMachine.Actions
{
    public class AGuard : Action
    {
        private BossController boss; //POR HACER EL BOSS CONTROLLER

        public AGuard(BossController boss)
        {
            this.boss = boss;
        }
        public override void Execute()
        {
            //aqui estaria la logica de como se comportaria el boss
        }
    }
}
