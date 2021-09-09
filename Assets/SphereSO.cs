using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SphereSO", menuName = "Unity-Editor-Tutorial/SphereSO", order = 0)]
public class SphereSO : ScriptableObject
{
    public float x, y, z;
    public Color color;
    public GameObject gameObject;
    public string gameobjectName;
}
