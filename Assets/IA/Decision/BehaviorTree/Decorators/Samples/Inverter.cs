using UnityEngine;

namespace IA26Online.Decision.BehaviorTree.Decorator
{
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

