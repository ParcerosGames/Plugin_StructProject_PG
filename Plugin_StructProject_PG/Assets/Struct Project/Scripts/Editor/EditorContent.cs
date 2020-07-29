using System;
using UnityEditor;
using UnityEngine;

public class EditorContent : EditorWindow
{
    internal GameObject newEmpty;

    [MenuItem("Window/StructProject/Preferences")]
    static void OpenWindows()
    {
        EditorContent window = GetWindow<EditorContent>("Preferences");
        window.minSize = new Vector2(600, 500);
        window.maxSize = new Vector2(600, 500);
        window.Show();
    }

    //private void OnEnable()
    //{
    //    EditorWindowsView.VerifyComponentInHierarchy();
    //}

    private void OnGUI()
    {
        VerifyObjectInEditor();
    }

    #region Create Label Button
    internal void VerifyObjectInEditor()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Object Instance");
        newEmpty = EditorGUILayout.ObjectField(newEmpty, typeof(GameObject), true) as GameObject;
        newEmpty = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Struct Project/Object/EmptyContent.prefab");
        EditorGUILayout.EndHorizontal();
    } 
    #endregion

}
