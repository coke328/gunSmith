using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectReverse", menuName = "ScriptableObject/ScriptableObjectReverse")]
public class ScriptableObjectReverse : ScriptableObject
{
    public GameObject obj;
    public float defaultSpread;
    public float moveSpread;
    public float zoomSpread;
    public float fireSpread;
    public float ads;
}
