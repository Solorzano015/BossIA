using UnityEngine;

namespace IA26Online.Decision.StateMachine.Actions
{
    public class AMeleeAttackPhase1_2 : Action
    {
        private BossController boss; //POR HACER EL BOSS CONTROLLER

        public AMeleeAttackPhase1_2(BossController boss)
        {
            this.boss = boss;
        }
        public override void Execute()
        {
            Debug.Log("Ataque Melee 2 - Phase 1");
        }
    }
}