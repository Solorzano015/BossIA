using UnityEngine;
using IA26Online.Decision.BehaviorTree;

namespace IA26Online.Decision.BehaviorTree
{

    public abstract class Task : ScriptableObject //[CreateAssetMenu(fileName = "DebugActions", menuName = "Decision/DecisionTree/Sample/DebugAction")]
    {
        //esta sera la estructura de las tasks
        public abstract bool Run();

    }

}


