using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SOEditorContent", menuName = "SOEditor")]
public class SOEditorContent : ScriptableObject
{
    public List<ModeHierarchy> modeHierarchies; 
    public Gradient myGradient;

    [System.Serializable]
    public class ModeHierarchy
    {
        public string newNameInstance;
        public Color newColor;
        public GameObject instanceHierarchy;
    }
}


