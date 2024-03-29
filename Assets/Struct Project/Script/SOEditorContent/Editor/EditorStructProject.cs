﻿using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Video;

[CustomEditor(typeof(SOEditorContent))]
public class EditorStructProject : Editor
{
    public static SOEditorContent sOEditorContent;

    //search object in hierarchy
    private GameObject[] objectsHierarchy;
    private GameObject refObjectHierarchyLocal;

    //Creare object in hierarchy
    private GameObject Empty;
    private GameObject refEmpty;

    //Font
    private GUISkin skinTitle;
    private GUISkin skinInfo;

    private void OnEnable()
    {
        skinTitle = Resources.Load<GUISkin>("GuiSkin/TitleSkin");
        skinInfo = Resources.Load<GUISkin>("GuiSkin/infoSkin");
        Empty = Resources.Load<GameObject>("SOEditor/ObjectID");

        sOEditorContent = Resources.Load<SOEditorContent>("SOEditor/EditorHierarchyCustom");
    }

    public override void OnInspectorGUI()
    {
        //VerifyObjectInHierarchy();

        GUILayout.BeginHorizontal("Box");
        GUILayout.Label("STRUCT PROJECT", skinTitle.GetStyle("Header1"));
        GUILayout.EndHorizontal();

        GUILayout.Space(5);

        GUILayout.BeginHorizontal("Box");
        GUILayout.Label("This plugin will help users to organize their objects in a hierarchy in a more professional way, " +
            "it will also be adapted for project panel files." +
            "The functionalities that it would have would be several in the long term, among them, " +
            "the change of color of the objects in hierarchy, adding icons to said objects, among other functions. " + 
            "\n" + "\n" + 
            "Maintaining order in our activities is something that we all must do for a better operation, and in our projects it must be a priority, " +
            "since it helps us control everything in a much easier way, this plugin addresses those small problems of all <color=#00C1DD>Unity developers</color> " +
            "who do not know how to name their projects, which nomenclature would be the right one for that project ?, if it is a 2D platform project, " +
            "what should I use ?, if it is a third person shooter, or even, if it is a VR project of the industrial sector.The solution is already in your hands, " +
            "stop thinking about that architecture, because you already have the solution.", skinInfo.GetStyle("Header2"));
        GUILayout.EndHorizontal();

        GUILayout.Space(5);
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("colorText"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("styleText"));
        GUILayout.Space(5);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("newNameInstance"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("newColor"));
        serializedObject.ApplyModifiedProperties();

        GUILayout.Space(15);
        GUILayout.BeginHorizontal("Box");
        ButtonApply();
        GUILayout.EndHorizontal();
    }

    #region Settings Empty In Hierarchy
    internal void ButtonApply()
    {
        if (GUILayout.Button("Apply", skinTitle.GetStyle("Header1")))
        {
            if (!refEmpty)
            {
                CreateObjectInHierarchy();
                //VerifyObjectInHierarchy();
            }
        }
    }
    int indexName;
    internal void CreateObjectInHierarchy()
    {
        indexName = -1;

        for (int i = 0; i < sOEditorContent.newColor.Length; i++)
        {
            indexName++;
            refEmpty = Instantiate(Empty);
            refEmpty.name = sOEditorContent.newNameInstance[indexName];
            refEmpty.GetComponent<LightHierarchy>().colorHierarchy = sOEditorContent.newColor[i];
            refEmpty.GetComponent<LightHierarchy>().colorText = sOEditorContent.colorText;
            refEmpty.GetComponent<LightHierarchy>().styleText = sOEditorContent.styleText;
        }
    }

    internal void VerifyObjectInHierarchy()
    {
        objectsHierarchy = FindObjectsOfType<GameObject>();
        foreach (var refObjectHierarchy in objectsHierarchy)
        {
            refObjectHierarchyLocal = refObjectHierarchy;

            if (refObjectHierarchyLocal.activeInHierarchy)
            {
                AddcomponentToNewEmpty(refObjectHierarchyLocal.transform);
            }
        }
    }
    internal void AddcomponentToNewEmpty(Transform item)
    {
        foreach (var refObjectHierarchyLocal in objectsHierarchy)
        {
            if (refObjectHierarchyLocal.GetComponentInParent<Camera>())
            {
                if (item.name == "CM CAMERA")
                {
                    refObjectHierarchyLocal.transform.parent = item;
                }
            }
            else if (refObjectHierarchyLocal.GetComponent<Light>())
            {
                if (item.name == "LIGHTING")
                {
                    refObjectHierarchyLocal.transform.parent = item;
                }
            }
            else if (refObjectHierarchyLocal.GetComponent<EventSystem>()|| refObjectHierarchyLocal.GetComponent<VideoPlayer>())
            {
                if (item.name == "SETTINGS")
                {
                    refObjectHierarchyLocal.transform.parent = item;
                }
            }
            else if (refObjectHierarchyLocal.GetComponent<Canvas>())
            {
                if (item.name == "UI")
                {
                    refObjectHierarchyLocal.transform.parent = item;
                }
            }
            else if (refObjectHierarchyLocal.GetComponent<ParticleSystem>()
                || refObjectHierarchyLocal.GetComponent<ParticleSystemForceField>()
                || refObjectHierarchyLocal.GetComponent<TrailRenderer>()
                || refObjectHierarchyLocal.GetComponent<LineRenderer>())
            {
                if (item.name == "EFFECTS")
                {
                    refObjectHierarchyLocal.transform.parent = item;
                }
            }
            else if (refObjectHierarchyLocal.GetComponent<AudioSource>() || refObjectHierarchyLocal.GetComponent<AudioReverbZone>())
            {
                if (item.name == "SOUND")
                {
                    refObjectHierarchyLocal.transform.parent = item;
                }
            }
            else if (refObjectHierarchyLocal.GetComponent<Renderer>())
            {
                if (item.name == "ENVIROMENT")
                {
                    refObjectHierarchyLocal.transform.parent = item;
                }
            }
            else if (refObjectHierarchyLocal.GetComponent<Volume>())
            {
                if (item.name == "POST PROCESS")
                {
                    refObjectHierarchyLocal.transform.parent = item;
                }
            }

        }
    }
    #endregion
}
