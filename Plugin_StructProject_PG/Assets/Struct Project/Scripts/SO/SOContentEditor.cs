using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOContent", menuName = "SO")]
public class SOContentEditor : ScriptableObject
{
    [SerializeField] internal GameObject[] names;
}
