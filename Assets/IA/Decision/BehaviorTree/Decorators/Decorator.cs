
namespace IA26Online.Decision.BehaviorTree.Decorator
{

    public abstract class Decorator : Task
    {

        protected Task task;

        public Decorator(Task task)
        {
            this.task = task;
        }

    }

}


