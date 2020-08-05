using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class AnimalsEditorWindow : EditorWindow
{
    const int TOP_PADDING = 2;
    const string HELP_TEXT = "Can not find 'Animals' component on any GameObject in the Scene.";

    static Vector2 s_WindowsMinSize = Vector2.one * 300.0f;
    static Rect s_HelpRect = new Rect(0.0f, 0.0f, 300.0f, 100.0f);
    static Rect s_ListRect = new Rect(Vector2.zero, s_WindowsMinSize);

    [MenuItem("Window/Animals/Open Window")]
    static void Initialize()
    {
        AnimalsEditorWindow window = EditorWindow.GetWindow<AnimalsEditorWindow>(true, "Make Animal List");
        window.minSize = s_WindowsMinSize;
    }

    SerializedObject m_AnimalsSO = null;
    ReorderableList m_ReorderableList = null;
    SOContentEditor animals = new SOContentEditor();

    void OnEnable()
    {
        
        //SOContentEditor animals = FindObjectOfType<SOContentEditor>();
        if (animals)
        {
            m_AnimalsSO = new SerializedObject(animals);
            m_ReorderableList = new ReorderableList(m_AnimalsSO, m_AnimalsSO.FindProperty("names"), true, true, true, true);

            m_ReorderableList.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "Animal Names");
            m_ReorderableList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                rect.y += TOP_PADDING;
                rect.height = EditorGUIUtility.singleLineHeight;
                EditorGUI.PropertyField(rect, m_ReorderableList.serializedProperty.GetArrayElementAtIndex(index));
            };
        }
    }

    void OnInspectorUpdate()
    {
        Repaint();
    }

    void OnGUI()
    {
        if (m_AnimalsSO != null)
        {
            m_AnimalsSO.Update();
            m_ReorderableList.DoList(s_ListRect);
            m_AnimalsSO.ApplyModifiedProperties();
        }
        else
        {
            EditorGUI.HelpBox(s_HelpRect, HELP_TEXT, MessageType.Warning);
        }
    }
}
