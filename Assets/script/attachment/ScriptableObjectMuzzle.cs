using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectMuzzle", menuName = "ScriptableObject/ScriptableObjectMuzzle")]
public class ScriptableObjectMuzzle : ScriptableObject
{
    public GameObject obj;
    public float defaultSpread;
    public float moveSpread;
    public float zoomSpread;
    public float fireSpread;
    public float bulletSpeed;
    public float ads;
}
