using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectGunBody", menuName = "ScriptableObject/ScriptableObjectGunBody")]
public class ScriptableObjectGunBody : ScriptableObject
{
    public GameObject obj;
    public AnimationClip animClip;
    public Vector2 barrelOffsetPos;
    public Vector2 HandGuardOffsetPos;
    public Vector2 dotOffsetPos;
    public Vector2 magOffsetPos;
    public Vector2 reverseOffsetPos;
    public float defaultSpread;
    public float moveSpread;
    public float zoomSpread;
    public float fireSpread;
    public float damage;
    public float semiFireRate;
    public float burstFirerate;
    public float autoFireRate;
    public float bulletSpeed;
    public float zoomRange;
    public float fireDelay;
    public float zoomScreenSize;
    public float ads;
    public bool semi;
    public bool burst;
    public bool auto;
    public int gunType;
}
