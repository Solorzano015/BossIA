using UnityEngine;

namespace IA26Online.Decision.StateMachine.Actions
{
    public class ARangeAttackPhase1 : Action
    {
        private BossController boss; //POR HACER EL BOSS CONTROLLER

        public ARangeAttackPhase1(BossController boss)
        {
            this.boss = boss;
        }
        public override void Execute()
        {
            //logica del ataque a distancia de la phase 1
        }
    }
}
