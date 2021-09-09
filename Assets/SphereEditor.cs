using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(SphereSO))]
public class SphereEditor : Editor
{

    SerializedObject so;
    SerializedProperty propColor;
    SerializedProperty go, goName;
    SerializedProperty x, y, z;
    private void OnEnable()
    {
        so = serializedObject;
        propColor = so.FindProperty("color");
        x = so.FindProperty("x");
        y = so.FindProperty("y");
        z = so.FindProperty("z");
        go = so.FindProperty("gameObject");
        goName = so.FindProperty("gameobjectName");
    }
    public override void OnInspectorGUI()
    {
        so.Update();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.PropertyField(propColor);
        EditorGUILayout.PropertyField(go);
        EditorGUILayout.PropertyField(goName);
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.PropertyField(x);
        EditorGUILayout.PropertyField(y);
        EditorGUILayout.PropertyField(z);
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        so.ApplyModifiedProperties();
        if (GUILayout.Button("Apply Properties"))
        {
            foreach (Sphere sphere in FindObjectsOfType<Sphere>())
            {
                sphere.ApplyModification();
            }
        }
        if (GUILayout.Button("Instantiate"))
        {
            foreach (Sphere sphere in FindObjectsOfType<Sphere>())
            {
                sphere.instantiateNewObject();
            }
        }
    }
}