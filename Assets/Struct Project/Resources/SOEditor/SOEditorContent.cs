using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEditorContent", menuName = "SOEditor")]
public class SOEditorContent : ScriptableObject
{
    public List<ModeHierarchy> modeHierarchies; 

    [System.Serializable]
    public class ModeHierarchy
    {
        public string newNameInstance;
        public Color newColor;
        public GameObject instanceHierarchy;
    }
}




