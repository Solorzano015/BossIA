
using IA26Online.Agents;
using IA26Online.Decision.BehaviorTree;
using UnityEngine;

namespace IA26Online.Decision.BehaviorTree
{
    [CreateAssetMenu(fileName = "Selector", menuName = "Decision/BehaviourTree/Selectors")]


    public class Selectors : Task //tarea de composicion
    {
        [SerializeField] private Task[] children;

        
        public Selectors(Task[] children) //ya que no hereda de MonoBeahaviour
        {
            this.children = children;
        }
        

        public override bool Run(Boss boss)
        {
            //por cada hijo que lo este ejecutando devolvera
            foreach (Task child in children)
            {
                if (child.Run(boss) == true)
                    return true;
            }
            return false;
        }
    }
}


