using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class SphereWindowEditor : EditorWindow
{

    [MenuItem("Unity-Editor-Tutorial/SphereWindow")]
    private static void ShowWindow()
    {
        var window = GetWindow<SphereWindowEditor>();
        window.titleContent = new GUIContent("SphereWindow");
        window.Show();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Snap"))
        {
            SnapSelection();
        }
    }

    private void SnapSelection()
    {
        foreach (GameObject go in UnityEditor.Selection.gameObjects)
        {
            Undo.RecordObject(go.transform, "Undo Transform");
            Round(go.transform);
        }
    }

    private void Round(Transform transformGO)
    {
        Vector3 v = new Vector3();
        v.x = Mathf.Round(transformGO.position.x);
        v.y = Mathf.Round(transformGO.position.y);
        v.z = Mathf.Round(transformGO.position.z);
        transformGO.position = v;
    }
}