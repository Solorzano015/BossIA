using UnityEngine;

namespace IA26Online.Decision.BehaviorTree.Decorators.Sample
{
    [CreateAssetMenu(fileName = "Inverters", menuName = "Decision/BehaviourTree/Decorators/Inverters")]
    public class Inverter : Decorator
    {
        public Inverter(Task task) : base(task)
        {
        }

        public override bool Run()
        {
            return !task.Run();
        }
    }
}
//con la misma clase, condicion, puedo evaluar dos situaciones
//que por defecto se tendrian que hacer por separado. Ej: evaluar dist de un obj
