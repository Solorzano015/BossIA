using IA26Online.Decision.StateMachine;
using System.Xml.Schema;
using UnityEngine;

namespace IA26Online.Decision.StateMachine
{
    public class FloatCondition : Condition
    {
        //valor_mínimo : float
        private float min_value;
        //valor_máximo : float
        private float max_value;

        //float TestValue()
        private System.Func<float> testValue;

        //constructor para poder inicializar
        public FloatCondition(float min, float max, System.Func<float> valueGetter)
        {
            min_value = min;
            max_value = max;
            testValue = valueGetter;
        }

        //bool Test()
        //{
        //    return valor_mínimo <= TestValue() <= valor_máximo
        //}
        private float TestValue()
        {
            return testValue();
        }
        public override bool Test()
        {
            float value = TestValue();
            if (min_value <= value && value <= max_value == true)
                return true;
            return false;
        }
    }
}
