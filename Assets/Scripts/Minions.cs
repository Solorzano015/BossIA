using IA26Online.Decision.BehaviorTree;
using IA26Online.Decision.BehaviorTree.Samples;
using IA26Online.Decision.BehaviorTree.Decorators.Sample;
using UnityEngine;

public class Minions : MonoBehaviour
{
    [SerializeField] private Task root; //esta en la copa del arbol pero lo llamamos "root"

    private Blackboard.BlackboardData blackboardData; //al estar fuera se puede llamar asi 


    
    //PUEDO QUITARLO SI LO HAGO CON SCRIPTABLE OBJ
    private void Awake()
    {
        //root = new Task(); -> no se puede porque es abstracta entonces
        root = new Selectors(
            new Task[]
            {
                new DebugAction("Hola"),  //hijos del root, es un nodo

                new Inverter(new DebugAction("Hola")) //lo invierte y lo true pasa a false
            }
        ); //tenemos un selector y su primer hijo es un debug action
    }
    
    private void Update()
    {
        root.Run();
    }
}
