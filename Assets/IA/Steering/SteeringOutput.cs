using VectorAI = UnityEngine.Vector2; //nuestro propio using no importa el nombre, se puede cambiar a 3D desde aqui.
                                      //Aun asi esto se enfoca mas en C++

namespace IA26Online.Steering //agrupacion entre varios scripts y cuando se compile el proyecto por completo, solo se compilen o se recompilen los scripts que han sido variados.
{ //se puede poner cualquier nombre, ponerlo siempre en todos !!!
    public struct SteeringOutput
    {
        //estructura 
        public VectorAI linear;
        public float angular;

        public SteeringOutput(VectorAI linear, float angular)
        {
            this.linear = linear;
            this.angular = angular;
        }

        //vamos a sobrecargar un operador
        public static SteeringOutput operator +(SteeringOutput left, SteeringOutput right)
        {
            return new SteeringOutput
                (
                left.linear + right.linear,
                left.angular + right.angular
                );
        }
        public static SteeringOutput operator *(SteeringOutput a, float value)
        {
            return new SteeringOutput
                (
                a.linear * value,
                a.angular * value
                );
        }
    }
}
