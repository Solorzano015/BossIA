using UnityEngine;

namespace IA26Online.Decision.StateMachine.Actions
{
    public class ASpecialAttack : Action
    {
        private BossController boss; //POR HACER EL BOSS CONTROLLER

        public ASpecialAttack(BossController boss)
        {
            this.boss = boss;
        }
        public override void Execute()
        {
            //logica del ataque especial
        }
    }
}
