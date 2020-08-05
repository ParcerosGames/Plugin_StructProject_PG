using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "SOEditorContent", menuName = "SOEditor")]
public class SOEditorContent : ScriptableObject
{
    public List<ModeHierarchy> modeHierarchies;
    public UnityEvent eventU;

    [System.Serializable]
    public class ModeHierarchy
    {
        public Color newColor;
        public GameObject emptyInstance;
    }

}
