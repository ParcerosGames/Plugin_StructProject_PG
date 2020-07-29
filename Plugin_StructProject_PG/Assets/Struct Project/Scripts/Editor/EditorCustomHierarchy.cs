using System.Reflection.Emit;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class EditorCustomHierarchy : MonoBehaviour
{
    static EditorCustomHierarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI -= HierarchyWindowItemOnGUI;
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
    }

    static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        if(obj != null && obj.name.StartsWith("--", System.StringComparison.Ordinal))
        {
            if (!obj.GetComponent<HierarchySettings>())
                obj.AddComponent<HierarchySettings>();

            HierarchySettings Label = obj.GetComponent<HierarchySettings>();

            float alpha = 1.0f;
            Label.gradient = new Gradient();
            Label.gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Label.backgroundColor, .5f), new GradientColorKey(Color.white, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, .2f), new GradientAlphaKey(0, 1.0f) }
            );
            EditorGUI.DrawRect(selectionRect, Label.backgroundColor);
            EditorGUI.DropShadowLabel(selectionRect, obj.name.Replace("-", "").ToString());

            Label.icon = (Texture2D)EditorGUILayout.ObjectField(Label.icon, typeof(Texture2D), true, GUILayout.Width(30));

            //opt.icon = (Texture2D)EditorGUILayout.ObjectField(opt.icon, typeof(Texture2D), false, GUILayout.Width(30));
            //opt.iconLeft = EditorGUILayout.Toggle(opt.iconLeft, GUILayout.Width(20));
            //opt.iconOffs = EditorGUILayout.IntField(opt.iconOffs, GUILayout.Width(30));

        }
    }
}
