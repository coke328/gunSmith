using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectGrib", menuName = "ScriptableObject/ScriptableObjectGrib")]
public class ScriptableObjectGrib : ScriptableObject
{
    public GameObject obj;
    public float defaultSpread;
    public float moveSpread;
    public float zoomSpread;
    public float fireSpread;
    public float ads;
}
