using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Video;

[CustomEditor(typeof(SOEditorContent))]
public class EditorStructProject : Editor
{
    public static SOEditorContent sOEditorContent;

    private SerializedProperty propertySOEditorContent;

    //search object in hierarchy
    private GameObject[] objectsHierarchy;
    private GameObject refObjectHierarchyLocal;

    //Creare object in hierarchy
    private GameObject refEmpty;

    //Font
    private GUISkin skinTitle;
    private GUISkin skinInfo;

    private void OnEnable()
    {
        skinTitle = Resources.Load<GUISkin>("GuiSkin/TitleSkin");
        skinInfo = Resources.Load<GUISkin>("GuiSkin/infoSkin");

        sOEditorContent = Resources.Load<SOEditorContent>("SOEditor/SOEditorContent");

        propertySOEditorContent = serializedObject.FindProperty("modeHierarchies");
    }

    public override void OnInspectorGUI()
    {
        //VerifyObjectInHierarchy();

        GUILayout.BeginHorizontal("Box");
        GUILayout.Label("STRUCT PROJECT", skinTitle.GetStyle("Header1"));
        GUILayout.EndHorizontal();

        GUILayout.Space(5);

        GUILayout.BeginHorizontal("Box");
        GUILayout.TextArea("This plugin will help users to organize their objects in a hierarchy in a more professional way, " +
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
        GUILayout.BeginHorizontal("Box");
        serializedObject.Update();
        EditorGUILayout.PropertyField(property: propertySOEditorContent, includeChildren: true);
        serializedObject.ApplyModifiedProperties();
        GUILayout.EndHorizontal();

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
            }
        }
    }

    internal void CreateObjectInHierarchy()
    {
        for (int i = 0; i < sOEditorContent.modeHierarchies.Count; i++)
        {
            refEmpty = Instantiate(sOEditorContent.modeHierarchies[i].instanceHierarchy);
            refEmpty.name = sOEditorContent.modeHierarchies[i].newNameInstance;
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
            else if (refObjectHierarchyLocal.GetComponent<EventSystem>() || refObjectHierarchyLocal.GetComponent<Volume>()
                || refObjectHierarchyLocal.GetComponent<VideoPlayer>())
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

        }
    }
    #endregion
}
