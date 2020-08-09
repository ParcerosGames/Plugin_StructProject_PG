using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SOEditorContent", menuName = "SOEditor")]
public class SOEditorContent : ScriptableObject
{
    [SerializeField] internal List<ModeHierarchy> modeHierarchies;
    [SerializeField] internal UnityEvent[] eventU;

}

[System.Serializable]
public class ModeHierarchy
{
    [SerializeField] internal string nameEmpty;
    [SerializeField] internal Color newColor;
    public GameObject emptyInstance;
}
