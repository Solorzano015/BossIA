using IA26Online.Agents;
using UnityEngine;

namespace IA26Online.Decision.BehaviorTree.Actions
{
    // Contraataque C a C: se dispara si tras el ataque el jugador sigue cerca (Sigue Cerca)
    [CreateAssetMenu(
    fileName = "CounterAttackAction",
    menuName = "Decision/BehaviourTree/Actions/CounterAttackAction")]
    public class CounterAttackAction : Task
    {
        

        public override bool Run(Boss boss)
        {
            // ... lógica del contraataque (daño extra, animación específica)
            Debug.Log("Contraataque");
            return true;
        }
    }
}