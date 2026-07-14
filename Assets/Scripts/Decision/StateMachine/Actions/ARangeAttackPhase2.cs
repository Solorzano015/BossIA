using UnityEngine;

namespace IA26Online.Decision.StateMachine.Actions
{
    public class ARangeAttackPhase2 : Action
    {
        private BossController boss; //POR HACER EL BOSS CONTROLLER

        public ARangeAttackPhase2(BossController boss)
        {
            this.boss = boss;
        }
        public override void Execute()
        {
            Debug.Log("Ataque a distancia - Fase 2");
        }
    }
}