using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SOEditorContent", menuName = "SOEditor")]
public class SOEditorContent : ScriptableObject
{
    public List<ModeHierarchy> modeHierarchies;
    public UnityEvent[] eventU;

    [System.Serializable]
    public class ModeHierarchy
    {
        [SerializeField] internal string nameEmpty;
        [SerializeField] internal Color newColor;
        [SerializeField] internal GameObject emptyInstance;
    }

}
