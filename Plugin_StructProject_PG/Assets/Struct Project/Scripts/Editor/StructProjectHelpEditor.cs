using Boo.Lang;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StructProjectHelpEditor : EditorWindow
{
    #region Head
    GUISkin skinTitle;
    Texture2D headBackgroundTexture;
    Rect headBackgroundRect;
    Color headBackgroundColor = new Color(0.1764706f, 0.1764706f, 0.1764706f);
    #endregion

    #region Panel Left
    Texture2D backgrounLeftTexture;
    Rect rectBackgroundLeft;
    GUISkin skinTitleContentLeft;
    Texture2D backgroundLeftTexture;
    Rect backgroundLeftRect;
    Color backgroundLeftColor = new Color(0.1764706f, 0.1764706f, 0.1764706f);

    Rect buttonBackgroundLeftRect;
    #endregion


    #region Object in Hierarchy
    //destroy all object in hierarchy
    GameObject[] objectsHierarchy;
    GameObject refObjectHierarchyLocal;

    //create object in hiearchy
    //GameObject newEmpty;
    GameObject newEmpty;
    #endregion

    [MenuItem("Window/StructProject/Help")]
    static void OpenWindows()
    {
        StructProjectHelpEditor window = GetWindow<StructProjectHelpEditor>("Struct Project");
        window.minSize = new Vector2(600, 400);
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

        #region All object enable in Hierarchy
        //objectsHierarchy = FindObjectsOfType<GameObject>();
        //foreach (var refObjectHierarchy in objectsHierarchy)
        //{
        //    refObjectHierarchyLocal = refObjectHierarchy;
        //    if (refObjectHierarchy.activeInHierarchy)
        //    {
        //        Debug.Log(refObjectHierarchyLocal);
        //    }
        //} 
        #endregion
    }
    void OnGUI()
    {
        DrawLayaoutHead();
        DrawHead();

        VerifyObjectInEditor();

        DrawLayaoutBGLeft();
        DrawLeft();
    }

    #region HEAD
    void StartTexture()
    {
        headBackgroundTexture = new Texture2D(1, 1);
        headBackgroundTexture.SetPixel(0, 0, headBackgroundColor);
        headBackgroundTexture.Apply();
    }
    void DrawLayaoutHead()
    {
        headBackgroundRect.x = 0;
        headBackgroundRect.y = 0;
        headBackgroundRect.width = Screen.width;
        headBackgroundRect.height = 80;

        GUI.DrawTexture(headBackgroundRect, headBackgroundTexture);
    }
    void DrawHead()
    {
        GUILayout.BeginArea(headBackgroundRect);
        GUILayout.Label("STRUCT PROJECT", skinTitle.GetStyle("Header1"));
        GUILayout.EndArea();
    }
    #endregion

    #region Content Left
    void StartTexturePanelLeft()
    {
        backgroundLeftTexture = new Texture2D(1, 1);
        backgroundLeftTexture.SetPixel(0, 0, backgroundLeftColor);
        backgroundLeftTexture.Apply();
    }
    void DrawLayaoutBGLeft()
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
    void DrawLeft()
    {
        GUILayout.BeginArea(rectBackgroundLeft);
        GUILayout.Label("Panel Left", skinTitleContentLeft.GetStyle("Header2"));
        GUILayout.EndArea();
    }
    #endregion

    #region Instance Empty In Hierarchy
    void VerifyObjectInEditor()
    {
        newEmpty = EditorGUILayout.ObjectField(newEmpty, typeof(GameObject), true) as GameObject;
        newEmpty = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Struct Project/Object/EmptyContent.prefab");
 
    }
    void CreateObjectInHierarchy()
    {
        GameObject refEmpty = Instantiate(newEmpty);

        if(refEmpty != null)
        {
            foreach (var item in refEmpty.GetComponentsInChildren<Transform>())
            {
                item.SetParent(null);
                refEmpty.name = "LIGHTING";
                
                //Agroud in parent
                //if (item.GetComponents<Component>().Length > 1)
                //{
                //    refEmpty.name = "PARENT";
                //    item.SetParent(null);
                //}

            }
        }

    } 
    #endregion
}

