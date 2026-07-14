using IA26Online.Decision.BehaviorTree;
using UnityEngine;

namespace IA26Online.Decision.BehaviorTree
{
    [CreateAssetMenu(fileName = "Sequences", menuName = "Decision/BehaviourTree/Sequences")]

    public class Sequences : Task //tarea de composicion
    {
        private Task[] children;

        public Sequences(Task[] children)
        {
            this.children = children;
        }

        public override bool Run()
        {
            foreach (Task child in children)
            {
                if (!child.Run() == true)
                    return false;
            }

            return true;
        }
    }
}


