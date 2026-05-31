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
    private Dictionary<string, float> hola;
    //private Hashtable <string, float> holaDict;


    private BlackboardData[] entradas; //lista ordenada

    private void Awake()
    {
        //entradas = new List<BlackboardData>();


        BlackboardData a = new BlackboardData("vida", 100.0f);
        entradas[0] = a;
        //entradas.Add(a);    

        BlackboardData b = new BlackboardData("posicion_torre", new Vector3(4, 0, 20));
        entradas[1] = b;

        BlackboardData c = new BlackboardData("vida", 20); //
        entradas[2] = c;

        // hola.Add("hola", 50);

        Debug.Log(GetDataByKey("vida"));


    }

    public object GetDataByKey(string clave)
    {

        foreach(BlackboardData data  in entradas)
        {
            if (data.clave == clave)
            {
                return data;
            }
        }

        return null;
    }

}
