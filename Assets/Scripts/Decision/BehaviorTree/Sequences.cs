namespace IA26Online.Decision.BehaviorTree
{
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


