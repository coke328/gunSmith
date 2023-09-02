using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legCtrl : MonoBehaviour
{
    public playerMovement pm;

    public int legMoveDir;
    private Animator anim;
    public float animSpeed;
    private int lastLegMoveDir = -1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        setAnim();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0,(-pm.Dir + 2) * 45,0);
        if(pm.moveDir != -1){
            legMoveDir = pm.moveDir - pm.Dir;
            if(legMoveDir > 4){
                legMoveDir -= 8;
            }else if(legMoveDir < -4){
                legMoveDir += 8;
            }
        }else{
            legMoveDir = 5;
        }

        if(legMoveDir != lastLegMoveDir && pm.moveDir != -1){
            setAnim();
            lastLegMoveDir = legMoveDir;
        }else if(pm.moveDir == -1 && lastLegMoveDir != 5){
            anim.SetFloat("animSpeed",animSpeed);
            anim.Play("idle");
            lastLegMoveDir = 5;
        }

    }
    void setAnim(){
        switch(legMoveDir){
            case 0:
                anim.SetFloat("animSpeed",animSpeed);
                anim.Play("Armature_001_frontWalk");
                break;
            case 1:
                anim.SetFloat("animSpeed",animSpeed);
                anim.Play("Armature_001_frontLeftWalk");
                break;
            case 2:
                anim.SetFloat("animSpeed",animSpeed);
                anim.Play("Armature_001_rightWalk");
                break;
            case 3:
                anim.SetFloat("animSpeed",-animSpeed);
                anim.Play("Armature_001_frontRightWalk");//
                break;
            case -1:
                anim.SetFloat("animSpeed",animSpeed);
                anim.Play("Armature_001_frontRightWalk");
                break;
            case -2:
                anim.SetFloat("animSpeed",-animSpeed);
                anim.Play("Armature_001_rightWalk");
                break;
            case -3:
                anim.SetFloat("animSpeed",-animSpeed);
                anim.Play("Armature_001_frontLeftWalk");//
                break;
            default:
                anim.SetFloat("animSpeed",-animSpeed);
                anim.Play("Armature_001_frontWalk");//
                break;
            }
    }
}
