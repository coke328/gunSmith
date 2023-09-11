using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectHandGuard", menuName = "ScriptableObject/ScriptableObjectHandGuard")]
public class ScriptableObjectHandGuard : ScriptableObject
{
    public Sprite img;
    public Vector2 gribOffsetPos;
    public float defaultSpread;
    public float moveSpread;
    public float zoomSpread;
    public float fireSpread;
    public float ads;
}
