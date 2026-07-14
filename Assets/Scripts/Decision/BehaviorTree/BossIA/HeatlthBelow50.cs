using IA26Online.Agents;

namespace IA26Online.Decision.BehaviorTree.Conditions
{
    // Vida < 50%
    // Nota: no hace falta acotar el rango con Vida >= 25, ya que al ser hijo de un
    // Selector, si Vida < 25 la primera rama (Huir) ya se ejecuta antes y corta la búsqueda.
    public class HealthBelow50 : Task
    {
        private Boss boss;

        public HealthBelow50(Boss boss) // constructor para la clase que no puede instanciar
        {
            this.boss = boss;
        }

        public override bool Run()
        {
            return boss.Health < 50f;
        }
    }
}