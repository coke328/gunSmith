using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunDir : MonoBehaviour
{
    public Transform gunholder;
    public float lookAngle;
    public float looky;
    public Transform gunP;
    public int divideAngle = 5;

    public float roundedAngle;
    public float distGun;
    private Transform child;

    void Start(){
        child = transform.GetChild(0);

        gunSet();
    }

    // Update is called once per frame
    void Update()
    {
        lookAngle = -gunP.eulerAngles.x;
        looky = Mathf.Sin(lookAngle / 180 * Mathf.PI);
        float round = roundAngle(-gunholder.eulerAngles.z - 90);
        float radian = (round) / 180 * Mathf.PI;
        roundedAngle = Mathf.Atan2(Mathf.Sin(radian) * looky,Mathf.Cos(radian)) * 180 / Mathf.PI;
        transform.localEulerAngles = new Vector3(0,roundedAngle,0);
    }
    float roundAngle(float angle){
        return Mathf.Round(angle / 90 * divideAngle) * 90 / divideAngle;
    }
    private void gunSet(){
        child.localPosition = new Vector3(0,0,-distGun);
    }
}
