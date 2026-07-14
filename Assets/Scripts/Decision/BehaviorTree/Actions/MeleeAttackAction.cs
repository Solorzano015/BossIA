using UnityEngine;
using IA26Online.Agents;

namespace IA26Online.Decision.BehaviorTree.Actions
{
    // Ataque C a C
    [CreateAssetMenu(
    fileName = "MeleeAttackAction",
    menuName = "Decision/BehaviourTree/Actions/MeleeAttackAction")]
    public class MeleeAttackAction : Task
    {

        

        public override bool Run(Boss boss)
        {
            float distance = Vector3.Distance(boss.transform.position, boss.Player.position);

            if (distance > boss.AttackRange)
                return false; // por si acaso: fuera de rango, la secuencia falla

            // ... lógica del golpe cuerpo a cuerpo (daño, animación, cooldown)
            boss.SeekBehaviour.GetSteering(); // se acerca/orienta al jugador con KSeek mientras golpea
            return true;
        }
    }
}