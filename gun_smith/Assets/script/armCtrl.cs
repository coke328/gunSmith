using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armCtrl : MonoBehaviour
{

    public displayGun displayGun_;
    private Transform rightArm;
    private Transform leftArm;
    public Transform rightTarget;
    public Transform leftTarget;
    public Transform gunRightHand;
    public Transform gunLeftHand;
    public Transform frontLeft_right;
    public Transform frontLeft_left;
    public Transform front_right;
    public Transform front_left;
    public Transform frontRight_right;
    public Transform frontRight_left;
    public Transform right_right;
    public Transform right_left;
    public Transform backRight_right;
    public Transform backRight_left;
    public Transform back_right;
    public Transform back_left;
    public Transform backLeft_right;
    public Transform backLeft_left;
    public Transform left_right;
    public Transform left_left;
    public Transform gunHolder;
    public playerMovement pm;

    private int lastDir = 0;

    void Start()
    {
        rightArm = transform.GetChild(0);
        leftArm = transform.GetChild(1);

        setShoulders();
    }

    // Update is called once per frame
    void Update()
    {
        if(pm.Dir != lastDir){
            setShoulders();
            lastDir = pm.Dir;
        }

        setTargets(gunRightHand.position,gunLeftHand.position);
    }
    
    void setShoulders(){
        switch(pm.Dir){
            case 0://right
                setShoulder(right_right.localPosition,right_left.localPosition);
                break;
            case 1://backRight
                setShoulder(backRight_right.localPosition,backRight_left.localPosition);
                break;
            case 2://back
                setShoulder(back_right.localPosition,back_left.localPosition);
                break;
            case 3://backLeft
                setShoulder(backLeft_right.localPosition,backLeft_left.localPosition);
                break;
            case 4://left
                setShoulder(left_right.localPosition,left_left.localPosition);
                break;
            case 5://frontLeft
                setShoulder(frontLeft_right.localPosition,frontLeft_left.localPosition);
                break;
            case 6://front
                setShoulder(front_right.localPosition,front_left.localPosition);
                break;
            case 7://frontRight
                setShoulder(frontRight_right.localPosition,frontRight_left.localPosition);
                break;
        }
    }

    void setShoulder(Vector3 right,Vector3 left)
    {

        rightArm.position = new Vector3(-2,0,0) + (right - displayGun_.gunHold.localPosition) / 3 * 4;
        leftArm.position = new Vector3(-2,0,0) + (left - displayGun_.gunHold.localPosition) / 3 * 4;
    }

    void setTargets(Vector3 right,Vector3 left)
    {
        rightTarget.position = right;
        leftTarget.position = left;
    }
}
