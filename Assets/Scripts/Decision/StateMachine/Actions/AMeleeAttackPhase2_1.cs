using UnityEngine;

namespace IA26Online.Decision.StateMachine.Actions
{
    public class AMeleeAttackPhase2_1 : Action
    {
        private BossController boss; //POR HACER EL BOSS CONTROLLER

        public AMeleeAttackPhase2_1(BossController boss)
        {
            this.boss = boss;
        }
        public override void Execute()
        {
            //logica del ataque primero de la phase 2
        }
    }
}
