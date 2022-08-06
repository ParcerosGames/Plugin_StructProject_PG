using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEditorContent", menuName = "SOEditor")]
public class SOEditorContent : ScriptableObject
{
    public Color colorText;
    public FontStyle styleText;

    public string[] newNameInstance = new string[]
    {
        "ENVIROMENT","SETTINGS","CM CAMERA","EFFECTS","SOUND","UI","SCRIPTING","LIGHTING","POST PROCESS"
    };

    public Color[] newColor;
}




