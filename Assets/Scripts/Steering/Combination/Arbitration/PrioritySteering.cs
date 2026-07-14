using System;
using UnityEngine;

namespace IA26Online.Steering.Combination.Arbitration
{
    public class PrioritySteering : MonoBehaviour
    {
        // VARIABLES
        
        [SerializeField]  private float epsilon = 0.1f;// Valor min para que un comportamiento mueva al agente

        [SerializeField]  public float max_linear_velocity;// Limites max de velocidad

        [SerializeField]  public float max_angular_velocity;

        private Rigidbody2D agent;

        [Serializable]
        public struct BehaviourPriority
        {
            // Referencia para cada algoritmo
            public SteeringBehaviour behaviour;

            
            // Cuanto menor sea el número, mayor prioridad tendrá.
            public int priority;

            
            public BehaviourPriority(SteeringBehaviour behaviour, int priority) // Constructor
            {
                this.behaviour = behaviour;
                this.priority = priority;
            }
        }

        

        // Lista que evaluará Arbitration
        [SerializeField]
        private BehaviourPriority[] behaviours;

             

        private void Awake()
        {
            
            agent = GetComponent<Rigidbody2D>();

            // prioridades de menor a mayor
            Array.Sort(behaviours, (a, b) => a.priority.CompareTo(b.priority));
        }

        //----------------------------------------------------

        private void Update()
        {
            // Steering Arbitration
            SteeringOutput sOut = GetSteering();

            
            agent.linearVelocity = sOut.linear; //movimiento al Rigidbody
            agent.angularVelocity = sOut.angular;
        }

        

        public SteeringOutput GetSteering()
        {
            // ultimo Steering calculado
            SteeringOutput sOut = new SteeringOutput();

            // todos los comportamientos de antes
            foreach (BehaviourPriority bp in behaviours)
            {
                //Steering del comportamiento actual
                sOut = bp.behaviour.GetSteering();

                //si la magnitud de sOut.lineal o el valor absoluto de sOut.angular superan el valor épsilon, return sOut
                // asegurar si se va a mover
                if (sOut.linear.magnitude > epsilon ||
                    Mathf.Abs(sOut.angular) > epsilon)
                {
                   

                    sOut.linear = Vector2.ClampMagnitude( sOut.linear, max_linear_velocity);  // limitar velocidad

                    sOut.angular = Mathf.Clamp( sOut.angular, -max_angular_velocity, max_angular_velocity);

                    // Con esa prioridad se devuelve el resultado 
                    return sOut;
                }

                // y si no queria mover al agente solo se sale
            }

            
            // devuelve un Steering vacio
            return new SteeringOutput();
        }
    }
}