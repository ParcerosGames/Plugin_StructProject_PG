using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class EditorWindowsView : EditorContent
{
    #region Head
    private GUISkin skinTitle;
    private Texture2D headBackgroundTexture;
    private Rect headBackgroundRect;
    private Color headBackgroundColor = new Color(0.1764706f, 0.1764706f, 0.1764706f);
    #endregion

    #region Panel Left
    private Texture2D backgrounLeftTexture;
    private Rect rectBackgroundLeft;
    private GUISkin skinTitleContentLeft;
    private Texture2D backgroundLeftTexture;
    private Rect backgroundLeftRect;
    private Color backgroundLeftColor = new Color(0.1764706f, 0.1764706f, 0.1764706f);

    private Rect buttonBackgroundLeftRect;
    #endregion
    
    #region Object in Hierarchy
    //search object in hierarchy
    private GameObject[] objectsHierarchy;
    private GameObject refObjectHierarchyLocal;

    //Creare object in hierarchy
    private GameObject refEmpty;
    #endregion

    [MenuItem("Window/StructProject/Struct Project")]
    static void OpenWindows()
    {
        EditorWindowsView window = GetWindow<EditorWindowsView>("Struct Project");
        window.minSize = new Vector2(600, 500);
        window.maxSize = new Vector2(600, 500);
        window.Show();
    }
    private void OnEnable()
    {
        skinTitle = Resources.Load<GUISkin>("GuiSkin/TitleSkin");
        skinTitleContentLeft = Resources.Load<GUISkin>("GuiSkin/TitleContentLeft");
        backgrounLeftTexture = Resources.Load<Texture2D>("Image/bgImageLeft");

        StartTexture();
        StartTexturePanelLeft();
    }
    private void OnGUI()
    {
        VerifyObjectInEditor();
        DrawLayaoutHead();
        DrawHead();

        DrawLayaoutBGLeft();
        DrawLeft();

        VerifyObjectInHierarchy();
    }

    #region Head
    private void StartTexture()
    {
        headBackgroundTexture = new Texture2D(1, 1);
        headBackgroundTexture.SetPixel(0, 0, headBackgroundColor);
        headBackgroundTexture.Apply();
    }
    private void DrawLayaoutHead()
    {
        headBackgroundRect.x = 0;
        headBackgroundRect.y = 0;
        headBackgroundRect.width = Screen.width;
        headBackgroundRect.height = 80;

        GUI.DrawTexture(headBackgroundRect, headBackgroundTexture);
    }
    private void DrawHead()
    {
        GUILayout.BeginArea(headBackgroundRect);
        GUILayout.Label("STRUCT PROJECT", skinTitle.GetStyle("Header1"));
        GUILayout.EndArea();
    }
    #endregion

    #region Content Left
    private void StartTexturePanelLeft()
    {
        backgroundLeftTexture = new Texture2D(1, 1);
        backgroundLeftTexture.SetPixel(0, 0, backgroundLeftColor);
        backgroundLeftTexture.Apply();
    }
    private void DrawLayaoutBGLeft()
    {
        //Background
        rectBackgroundLeft.x = 50;
        rectBackgroundLeft.y = 100;
        rectBackgroundLeft.width = 240;
        rectBackgroundLeft.height = 270;

        GUI.DrawTexture(rectBackgroundLeft, backgrounLeftTexture);

        //Bar Up
        backgroundLeftRect.x = 50;
        backgroundLeftRect.y = 100;
        backgroundLeftRect.width = 240;
        backgroundLeftRect.height = 40;

        GUI.DrawTexture(backgroundLeftRect, backgroundLeftTexture);

        //Button Apply
        buttonBackgroundLeftRect.x = 50;
        buttonBackgroundLeftRect.y = 390;
        buttonBackgroundLeftRect.width = 240;
        buttonBackgroundLeftRect.height = 40;

        EditorGUILayout.BeginHorizontal();
        if (GUI.Button(buttonBackgroundLeftRect, "Apply"))
        {
            Debug.Log("Print button apply!");

            CreateObjectInHierarchy();
            #region Destroy all object in hiearchy
            //foreach (var refObjectHierarchyLocal in objectsHierarchy)
            //{
            //    if (refObjectHierarchyLocal.activeInHierarchy)
            //    {
            //        DestroyImmediate(refObjectHierarchyLocal);
            //    }
            //} 
            #endregion
        }
        EditorGUILayout.EndHorizontal();
    }
    private void DrawLeft()
    {
        GUILayout.BeginArea(rectBackgroundLeft);
        GUILayout.Label("Panel Left", skinTitleContentLeft.GetStyle("Header2"));
        GUILayout.EndArea();
    }
    #endregion

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
            if (refObjectHierarchyLocal.GetComponent<Camera>())
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
            else if (refObjectHierarchyLocal.GetComponent<EventSystem>())
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
            //else if (refObjectHierarchyLocal.GetComponent<Transform>())
            //{
            //    if (item.name == "OTHER'S")
            //    {
            //        refObjectHierarchyLocal.transform.parent = item;
            //    }
            //}
        }
        
    }
    internal void CreateObjectInHierarchy()
    {
        refEmpty = Instantiate(newEmpty);

        if(refEmpty != null)
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

