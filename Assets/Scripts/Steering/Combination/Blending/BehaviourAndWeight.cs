using System;
using UnityEngine;

//PODRIA BORRARLO PORQUE LO HE MIGRADO A BLENDERSTEERING
namespace IA26Online.Steering.Combination.Blending
{
    [Serializable] //de esta forma nos aseguramos que Unity puede mostrarlo
    public struct BehaviourAndWeight
    {
        public SteeringBehaviour behaviour; //con esto nos referimos a un algor. (seek, flee, avoidance...)
        [Range(0, 1)] public float weight; //debera ser entre 1 y 0

        public BehaviourAndWeight(SteeringBehaviour behaviour, float weight) //creamos el constructor
        {
            this.behaviour = behaviour;
            this.weight = weight;
        }
    }
}

