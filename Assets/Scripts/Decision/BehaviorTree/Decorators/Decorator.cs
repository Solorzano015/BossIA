
namespace IA26Online.Decision.BehaviorTree.Decorators
{

    public abstract class Decorator : Task
    {
        protected Task task;

        public Decorator(Task task) //constructor para clase que no se puede instanciar y que no de problemas
        {
            this.task = task;
        }
    }
}