using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(SphereSO))]
public class SphereEditor : Editor
{

    SerializedObject so;//the current selected SphereSO object


    // property fields of the sphereSO
    SerializedProperty propColor;
    SerializedProperty go, goName;
    SerializedProperty x, y, z;


    #region Preview Of the gameobject

    Editor gameObjectEditor;
    GUIStyle bgColor = new GUIStyle(); // The background of the preview
    SphereSO sO; // Caching the SphereSo
    #endregion
    private void OnEnable()
    {
        so = serializedObject;
        propColor = so.FindProperty("color");
        x = so.FindProperty("x");
        y = so.FindProperty("y");
        z = so.FindProperty("z");
        go = so.FindProperty("gameObject");
        goName = so.FindProperty("gameobjectName");
        sO = (SphereSO)so.targetObject; // Casting the serializedobject into the cached so
        bgColor.normal.background = EditorGUIUtility.whiteTexture;
    }
    public override void OnInspectorGUI()
    {

        // Drawing the cells
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

        // End of the drawing cells


        so.ApplyModifiedProperties();
        //Applying Changes of the fields when finished


        //Apply Settings into the gameobjects
        if (GUILayout.Button("Apply Properties"))
        {
            foreach (Sphere sphere in FindObjectsOfType<Sphere>())
            {
                sphere.ApplyModification();
            }
        }
        //Apply Settings into the Editor Instantiate
        if (GUILayout.Button("Instantiate"))
        {
            foreach (Sphere sphere in FindObjectsOfType<Sphere>())
            {
                sphere.instantiateNewObject();
            }
        }


        //Creation the of the preview window to see changes before implementing them
        GameObject gameObject = (GameObject)EditorGUILayout.ObjectField(sO.gameObject, typeof(GameObject), true);
        if (gameObject != null)
        {
            gameObject.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", sO.color);
            if (gameObjectEditor == null)
                gameObjectEditor = Editor.CreateEditor(gameObject);
            gameObjectEditor.OnInteractivePreviewGUI(GUILayoutUtility.GetRect(256, 256), bgColor);
        }
    }
}