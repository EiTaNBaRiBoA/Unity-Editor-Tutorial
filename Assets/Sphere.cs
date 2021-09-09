using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Sphere : MonoBehaviour
{
    [SerializeField] public SphereSO sphereSO;


    private void OnEnable()
    {
        ApplyModification();
    }
    public void ApplyModification()
    {
        Vector3 v = new Vector3();
        v.x = sphereSO.x;
        v.y = sphereSO.y;
        v.z = sphereSO.z;
        this.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", sphereSO.color);
        gameObject.name = sphereSO.gameobjectName;


    }
    public void instantiateNewObject()
    {
        GameObject go = PrefabUtility.InstantiatePrefab(sphereSO.gameObject) as GameObject;
        go.AddComponent<Sphere>().sphereSO = sphereSO;
        EditorUtility.SetDirty(go); // making sure the new instantiated prefabs from editor aren't lost
    }
}
