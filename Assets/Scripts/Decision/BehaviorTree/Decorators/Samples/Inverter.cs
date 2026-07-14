using IA26Online.Agents;
using UnityEngine;

namespace IA26Online.Decision.BehaviorTree.Decorators.Sample
{
    [CreateAssetMenu(fileName = "Inverters", menuName = "Decision/BehaviourTree/Decorators/Inverters")]
    public class Inverter : Decorator
    {
        public Inverter(Task task) : base(task)
        {
        }

        public override bool Run(Boss boss)
        {
            return !task.Run(boss);
        }
    }
}
//con la misma clase, condicion, puedo evaluar dos situaciones
//que por defecto se tendrian que hacer por separado. Ej: evaluar dist de un obj
