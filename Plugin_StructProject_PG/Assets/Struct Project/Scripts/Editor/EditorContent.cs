﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class EditorContent : EditorWindow
{
    internal SOContentEditor sOContentEditor;
    internal GameObject newEmpty;
    internal Color colorEmpty;

    [MenuItem("Window/StructProject/Preferences")]
    static void OpenWindows()
    {
        EditorContent window = GetWindow<EditorContent>("Preferences");
        window.minSize = new Vector2(600, 500);
        window.maxSize = new Vector2(600, 500);
        window.Show();
    }

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

    } 
    #endregion

}
