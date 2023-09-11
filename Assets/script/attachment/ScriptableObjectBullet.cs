using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectBullet", menuName = "ScriptableObject/ScriptableObjectBullet")]
public class ScriptableObjectBullet : ScriptableObject
{
    public Sprite img;
    public float damage;
    public float bulletSpeed;
    public int pelletCnt = 1;
}
