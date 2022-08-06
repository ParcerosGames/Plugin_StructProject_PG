using System.Linq;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class EditorLightHierarchy
{
    public static readonly Color DEFAULT_COLOR_HIERARCHY_SELECTED = new Color(0.243f, 0.4901f, 0.9058f, 1f);
    private static int temp_iconsDrawedCount;

    static EditorLightHierarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI -= HierarchyHighlight_OnGUI;
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyHighlight_OnGUI;
    }

    private static void HierarchyHighlight_OnGUI(int inSelectionID, Rect inSelectionRect)
    {
        GameObject GO_Label = EditorUtility.InstanceIDToObject(inSelectionID) as GameObject;

        if (GO_Label != null)
        {
            LightHierarchy Label = GO_Label.GetComponent<LightHierarchy>();

            if(Label != null && Event.current.type == EventType.Repaint)
            {
                bool ObjectIsSelected = Selection.instanceIDs.Contains(inSelectionID);

                Color backgroundColor = Label.colorHierarchy;
                Color textColor = Label.colorText;
                FontStyle textStyle = Label.styleText;

                //Esta es la funcion que hace que se pueda desactivar en hierarchy
                if (!Label.isActiveAndEnabled)
                {
                    if (backgroundColor != LightHierarchy.DEFAULT_BACKGROUND_COLOR)
                        backgroundColor.a = backgroundColor.a * 0.5f;

                    textColor.a = textColor.a * 0.5f;
                }

                if (backgroundColor.a > 0f)
                {
                    Rect BackgroundOffset = new Rect(inSelectionRect.position, inSelectionRect.size);

                    if (Label.colorHierarchy.a < 1f || ObjectIsSelected)
                    {
                        EditorGUI.DrawRect(BackgroundOffset, LightHierarchy.DEFAULT_BACKGROUND_COLOR);
                    }

                    //verifica el color al estar seleccionado
                    if (ObjectIsSelected)
                        EditorGUI.DrawRect(BackgroundOffset, GUI.skin.settings.selectionColor/*Color.Lerp(GUI.skin.settings.selectionColor, backgroundColor, 0.3f)*/);
                    else
                        EditorGUI.DrawRect(BackgroundOffset, backgroundColor);

                    
                }

                Rect Offset = new Rect(inSelectionRect.position + new Vector2(17f, 0f), inSelectionRect.size);

                EditorGUI.LabelField(Offset, GO_Label.name, new GUIStyle()
                {
                    normal = new GUIStyleState() { textColor = textColor },
                    fontStyle = textStyle
                });

                EditorApplication.RepaintHierarchyWindow();               
            }

        }
    }
}
