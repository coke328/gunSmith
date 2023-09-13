using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectBarrel", menuName = "ScriptableObject/ScriptableObjectBarrel")]
public class ScriptableObjectBarrel : ScriptableObject
{
    public GameObject obj;
    public Vector2 muzzleOffsetPos;
    public int barrelLength;
    public float defaultSpread;
    public float moveSpread;
    public float zoomSpread;
    public float fireSpread;
    public float damage;
    public float bulletSpeed;
    public float ads;
}
