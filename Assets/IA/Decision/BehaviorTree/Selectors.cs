

using UnityEngine;

namespace IA26Online.Decision.BehaviorTree
{
    [CreateAssetMenu(fileName = "Selectors", menuName = "Decision/DecisionTree/Sample/DebugAction")]


    public class Selectors : Task
    {

        [SerializeField] private Task[] children;

        public Selectors(Task[] children)
        {
            this.children = children;
        }

        public override bool Run()
        {
            foreach (Task child in children)
            {
                if (child.Run() == true)
                {

                    return true;
                }
            }

            return false;
        }

    }

}


