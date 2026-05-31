using UnityEngine;

namespace IA26Online.Decision.BehaviorTree.Samples
{
    [CreateAssetMenu(fileName = "DebugActions", menuName = "Decision/DecisionTree/Sample/DebugAction")]

    public class DebugAction : Task
    {
        private readonly string message;

        public DebugAction(string message) //se crea constructor con variable para hacer debug en concreto S
        {
            this.message = message;

        }

        public override bool Run()
        {
            Debug.Log(message);
            return true; // 1) esto llega a ejecutarse entonces hay que devolver true 2) obliga a devolver un bool


        }
    }



}
