using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunHolder : MonoBehaviour
{
    public playerMovement pm;

    public gun Gun;

    private Transform gunPos;
    private Transform rightAim;
    private Transform leftAim;
    private float distToGun;

    void Start(){
        gunPos = transform.GetChild(0).GetComponent<Transform>();
        rightAim = gunPos.transform.GetChild(0).GetComponent<Transform>();
        leftAim = gunPos.transform.GetChild(1).GetComponent<Transform>();
        distToGun = gunPos.transform.localPosition.x;
    }

    void Update()
    {
        //transform.rotation = Quaternion.Euler(0,0,pm.direction);
        Vector3 globalMPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 tmp = transform.position - globalMPos;
        float r = Mathf.Atan2(-tmp.y,-tmp.x) * 180 / Mathf.PI;
        transform.rotation = Quaternion.Euler(0,0,r);
        pm.direction = r;

        tmp = gunPos.position - globalMPos;
        float distance = Distance(tmp.x,tmp.y);
        float leftLocalR = Gun.spread * Mathf.PI / 180;

        rightAim.localRotation = Quaternion.Euler(0,0,-Gun.spread);
        leftAim.localRotation = Quaternion.Euler(0,0,Gun.spread);

        if(Distance(transform.position.x - globalMPos.x,transform.position.y - globalMPos.y) > distToGun){
            Vector2 vec2 = angleCoordToCoord(-leftLocalR,distance);
            rightAim.localPosition = new Vector3(vec2.x,vec2.y,0);
            vec2 = angleCoordToCoord(leftLocalR,distance);
            leftAim.localPosition = new Vector3(vec2.x,vec2.y,0);
        }else{
            rightAim.localPosition = new Vector3(0,0,0);
            leftAim.localPosition = new Vector3(0,0,0);
        }

    }
    Vector2 angleCoordToCoord(float r,float d){
        Vector2 result = new Vector2(Mathf.Cos(r)*d,Mathf.Sin(r)*d);
        return result;
    }
    float Distance(float x,float y){    
        return Mathf.Sqrt(x*x+y*y);
    }
}
