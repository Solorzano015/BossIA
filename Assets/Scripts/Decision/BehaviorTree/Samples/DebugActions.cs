using UnityEngine;

namespace IA26Online.Decision.BehaviorTree.Samples
{
    [CreateAssetMenu(fileName = "DebugActions", menuName = "Decision/BehaviourTree/Sample/DebugAction")]

    public class DebugAction : Task //tarea de accion o decision
    {
        [SerializeField] private string message;

        public DebugAction(string message) //se crea constructor con variable para hacer debug en concreto S
        {
            this.message = message;
        }

        public override bool Run()
        {
            Debug.Log(message);
            return true;
            //1) esto llega a ejecutarse entonces hay que devolver true
            //2) obliga a devolver un bool. Por regla general las acciones devuleven true
        }
    }
}
