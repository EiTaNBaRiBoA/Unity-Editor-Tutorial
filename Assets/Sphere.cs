using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sphere : MonoBehaviour
{
    [SerializeField] public SphereSO sphereSO;



    public void ApplyModification()
    {
        Vector3 v = new Vector3();
        v.x = sphereSO.x;
        v.y = sphereSO.y;
        v.z = sphereSO.z;
        this.GetComponent<Renderer>().material.SetColor("_Color", sphereSO.color);
        gameObject.name = sphereSO.gameobjectName;


    }

    public void instantiateNewObject()
    {
        GameObject go = Instantiate(sphereSO.gameObject, Vector3.zero, Quaternion.identity);
        go.AddComponent<Sphere>().sphereSO = sphereSO;

    }
}
