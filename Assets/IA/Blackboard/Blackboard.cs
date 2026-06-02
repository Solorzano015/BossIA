using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;



/*
public class BlackboardData //no tiene asociacion con blackboard 
{

}

*/

public class Blackboard : MonoBehaviour
{
    //Si se pone aqui depende de blackboard y es cuando nadie mas va a utilizarla 
    public class BlackboardData 
    {
        public string clave;
        public Type tipo; //un tipo que queramos, rigid body, diccionario etc, 
        public object valor; //pertenece a sistema, cualquier valor que tenga una estructura definida, se encarga de almacenar y pasar de un lado a otro 

        public BlackboardData(string clave, object valor) //constructor 
        {
            this.clave = clave;
            //this.tipo = tipo;
            this.valor = valor;

            this.tipo = valor.GetType();

        }


    }
    //private Dictionary<string, float> hola;
    //private Hashtable <string, float> holaDict;


    private List<BlackboardData> entradas; //lista ordenada,va izq a dere

    private void Awake()
    {
        entradas = new List<BlackboardData>(); //se inicializa lista para que no haya problemas


        BlackboardData a = new BlackboardData("vida", 100.0f);
       // entradas[0] = a; //asi no funciona con el tipo de lista 
        entradas.Add(a);    

        BlackboardData b = new BlackboardData("posicion_torre", new Vector3(4, 0, 20));
        //entradas[1] = b;
        entradas.Add(b);

        BlackboardData c = new BlackboardData("kinematic", new Rigidbody()); //
        entradas.Add(c);

        // hola.Add("hola", 50); 


        //Debug.Log(GetDataByKey("posicion_torre")); // reccorrera todas las entradas hasta que la clve sea posicion_torre
        // en caso de que si la haya va a devolver su data 

        var dato = GetDataByKey<float>("vida");

    }

    public object GetDataByKey<T>(string clave) //al ser object puede devolver cualquier cosa y no le importa 
    {

        foreach(BlackboardData data  in entradas)
        {
            if (data.clave.CompareTo(clave) == 0) // comparar un string con un string
            {
                return (T)data.valor;
            }
        }

        return null;
    }

    //ya que se tiene el get data by key para ver datos, hacer otro para agregar los datos
    //y comprobar antes de incluir a la lista no haya uno con clave repetida y
    //para mas creativos, que la lista entradas no sea una ordenada sino una clave valor




}
