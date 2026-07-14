using UnityEngine;

namespace IA26Online.Decision.StateMachine.Actions
{
    public class AMeleeAttackPhase1_1 : Action
    {
        private BossController boss; //POR HACER EL BOSS CONTROLLER

        public AMeleeAttackPhase1_1(BossController boss)
        {
            this.boss = boss;
        }
        public override void Execute()
        {
            Debug.Log("Ataque Melee 1 - Phase 1");
        }
    }
}