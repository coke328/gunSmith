using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectMag", menuName = "ScriptableObject/ScriptableObjectMag")]
public class ScriptableObjectMag : ScriptableObject
{
    public Sprite img;
    public GameObject bullet;
    public float ads;
    public int magSize;
    public float reloadTime;
}
