using IA26Online.Agents;
using UnityEngine;

namespace IA26Online.Decision.BehaviorTree.Conditions
{
    // Vida < 50
    // Nota: no hace falta acotar el rango con Vida >= 25, ya que al ser hijo de un
    // Selector, si Vida < 25 la primera rama (Huir) ya se ejecuta antes y corta la búsqueda.
    [CreateAssetMenu(
    fileName = "HealthBelow50",
    menuName = "Decision/BehaviourTree/BossIA/HealthBelow50")]
    public class HealthBelow50 : Task
    {
        

        public override bool Run(Boss boss)
        {
            return boss.Health < 50f;
        }
    }
}