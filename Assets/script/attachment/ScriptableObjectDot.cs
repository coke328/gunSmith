using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectDot", menuName = "ScriptableObject/ScriptableObjectDot")]
public class ScriptableObjectDot : ScriptableObject
{
    public GameObject obj;
    public float zoomSpread;
    public float zoomRange;
    public float zoomScreenSize;
    public float ads;
}
