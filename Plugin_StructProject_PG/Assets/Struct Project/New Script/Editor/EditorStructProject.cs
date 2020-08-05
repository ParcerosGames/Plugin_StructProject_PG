using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Video;

[CustomEditor(typeof(SOEditorContent))]
public class EditorStructProject : Editor
{
    public SOEditorContent sOEditorContent;

    private SerializedProperty propertySOEditorContent;
    private SerializedProperty propertySOEditorContentEvent;
    private string[] nameNewEmpty = new string[] {"LIGHT","CM VIRTUAL","ENVIROMENT", "SETTINGS","UI","SOUND'S","EFFECT'S"};

    //search object in hierarchy
    private GameObject[] objectsHierarchy;
    private GameObject refObjectHierarchyLocal;

    //Creare object in hierarchy
    private GameObject refEmpty;

    private void OnEnable()
    {
        propertySOEditorContent = serializedObject.FindProperty("modeHierarchies");
        propertySOEditorContentEvent = serializedObject.FindProperty("eventU");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(property: propertySOEditorContent, includeChildren:true);
        EditorGUILayout.PropertyField(property: propertySOEditorContentEvent, includeChildren: true);
        serializedObject.ApplyModifiedProperties();

        VerifyObjectInHierarchy();
        ButtonApply();
    }

    public void ButtonApply()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Button Apply");

        if(GUILayout.Button("Apply"))
        {
            //Read element in modeHierarchy (Array)
            //foreach (var item in serializedObject.FindProperty("modeHierarchies"))
            //{
            //    UnityEngine.Debug.Log(item); 
            //}

            foreach (var item in sOEditorContent.modeHierarchies)
            {
                GameObject refInstance = Instantiate(item.emptyInstance);

                if (refInstance.GetInstanceID() == refInstance.GetInstanceID())
                {
                    UnityEngine.Debug.Log("The object some equals");

                    refInstance.name = nameNewEmpty[0];
                    //AQUI DEBO ORGANIZAR PARA QUE EL NOMBRE NO SE REPITA CUANDO SE INSTANCIE
                    if(refInstance.name == refInstance.name)
                    {
                        refInstance.name = nameNewEmpty[Random.Range(0, nameNewEmpty.Length)];
                    }
                }

                //if(item.emptyInstance.name.Equals("New Clone"))
                //{
                //    item.emptyInstance.name = "Hola";
                //}
                //else if (item.emptyInstance.name.Equals("New Clone"))
                //{
                //    item.emptyInstance.name = "Raro";
                //}
            }
            //CreateObjectInHierarchy();
        }

        GUILayout.EndHorizontal();
    }

    #region Settings Empty In Hierarchy
    internal void VerifyObjectInHierarchy()
    {
        objectsHierarchy = FindObjectsOfType<GameObject>();
        foreach (var refObjectHierarchy in objectsHierarchy)
        {
            refObjectHierarchyLocal = refObjectHierarchy;

            //if (refObjectHierarchyLocal.activeInHierarchy)
            //{
            //    //Debug.Log(refObjectHierarchyLocal);
            //    //AddcomponentToNewEmpty();
            //}
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
            else if (refObjectHierarchyLocal.GetComponent<EventSystem>() || refObjectHierarchyLocal.GetComponent<Volume>())
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
            else if (refObjectHierarchyLocal.GetComponent<Renderer>())
            {
                if (item.name == "ENVIROMENT")
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
            else if (refObjectHierarchyLocal.GetComponent<VideoPlayer>())
            {
                if (item.name == "OTHER'S")
                {
                    refObjectHierarchyLocal.transform.parent = item;
                }
            }
        }

    }
    internal void CreateObjectInHierarchy()
    {
        //refEmpty = Instantiate(propertySOEditorContent.);

        if (refEmpty != null)
        {
            foreach (var item in refEmpty.GetComponentsInChildren<Transform>())
            {
                item.SetParent(null);
                refEmpty.name = "LIGHTING";
                //refItem = item;

                AddcomponentToNewEmpty(item);
                #region Agroud in parent
                //if (item.GetComponents<Component>().Length > 1)
                //{
                //    crefEmpty.name = "PARENT";
                //    item.SetParent(null);
                //} 
                #endregion

            }
        }

    }


    #endregion
}
