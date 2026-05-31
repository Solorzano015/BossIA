using IA26Online.Decision.BehaviorTree;
using IA26Online.Decision.BehaviorTree.Samples;
using UnityEngine;

public class Minions : MonoBehaviour
{
    [SerializeField] private Task root; //esta en la cima del arbol a pesar de "root" porque se suele hacer asi
                                        //

    private Blackboard.BlackboardData blackboardData; //como esta afuera se puede llamar asi 













    private void Awake()
    {
        //root = new Task(); -> no se puede porque es abstracta entonces
        root = new Selectors(new Task[] { new DebugAction("Hola") }); // tenemos un selector y su primer hijo es un debug action 

    
    
    }
    private void Update()
    {
        root.Run();
    }



}
