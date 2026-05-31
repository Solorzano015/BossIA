using UnityEngine;

namespace IA26Online.Decision.BehaviorTree
{

    public abstract class Task : ScriptableObject // ? ara que funcione el     [CreateAssetMenu(fileName = "DebugActions", menuName = "Decision/DecisionTree/Sample/DebugAction")]

    {
        public abstract bool Run();

    }

}


