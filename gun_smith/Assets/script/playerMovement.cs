using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed;
    public float moveSpeed = 5f;
    public float maxSpeed = 2f;
    public float drag = 0.1f;
    public bool slowDown = false;
    public float lookAngle = 45f;
    private float verticalMultiply;
    private Rigidbody2D rb;
    private Animator anim;
    Vector2 input;
    public int presentAnimIdx = 2;
    public float direction = 0;
    public float dirRad;
    public int Dir;
    public int moveDir;
    public float sideMoveMultiply = 0.7f;
    public float criticalSpeed = 5f;
    private SpriteRenderer leftShoulderArmor;
    private SpriteRenderer front_backShoulderArmor;
    private SpriteRenderer rightShoulderArmor;
    private SpriteRenderer frontRightShoulderArmor;
    private SpriteRenderer frontLeftShoulderArmor;

    private Animator cloakAnim;
    private SpriteRenderer cloakspRend;

    private int lastDir = 0;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        verticalMultiply = Mathf.Sin(lookAngle/180*Mathf.PI);

        Transform tmp = transform.GetChild(3);
        leftShoulderArmor = tmp.GetChild(0).GetComponent<SpriteRenderer>();
        front_backShoulderArmor = tmp.GetChild(1).GetComponent<SpriteRenderer>();
        rightShoulderArmor = tmp.GetChild(2).GetComponent<SpriteRenderer>();
        frontRightShoulderArmor = tmp.GetChild(3).GetComponent<SpriteRenderer>();
        frontLeftShoulderArmor = tmp.GetChild(4).GetComponent<SpriteRenderer>();

        cloakAnim = transform.GetChild(4).GetComponent<Animator>();
        cloakspRend = transform.GetChild(4).GetComponent<SpriteRenderer>();

        setAnimation();
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        
        //Vector2 mPos = Input.mousePosition;
        //dirRad = Mathf.Atan2((mPos.y - Screen.height/2) / verticalMultiply,mPos.x - Screen.width/2);
        //direction = dirRad * 180 / Mathf.PI;
        bool found = false;
        for(int i=0; i<7; i++){
            float startRot = -157.5f + 45 * i;
            float endRot = startRot + 45;
            if(direction >= startRot && direction < endRot){
                Dir = (i+5) % 8;
                found = true;
            }
        }
        if(!found){
            Dir = 4;
        }

        if(input == new Vector2(0,0)){
            moveDir = -1;
        }else{
            int rawDir = (int)(Mathf.Atan2(input.y,input.x) * Mathf.Rad2Deg / 45);
            if(rawDir < 0){
                moveDir = rawDir + 8;
            }else{
                moveDir = rawDir;
            }
        }

        if(lastDir != Dir){//방향이 바꿨을때
            setAnimation();
            armorCtrl();
            lastDir = Dir;
        }
    }

    void FixedUpdate(){
        if(moveDir != -1 && maxSpeed > rb.velocity.magnitude){
            Vector2 f = input.normalized;

            float tmp = Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad * ((moveDir - Dir) * 45)));
            f *= (1 - tmp) + tmp * sideMoveMultiply;

            f *= moveSpeed;
            f.y *= verticalMultiply;
            rb.AddForce(f,ForceMode2D.Force);

            if(rb.velocity.magnitude != 0){
                float dotToLine = input.normalized.y*rb.velocity.x-input.normalized.x*rb.velocity.y;
                float linearDrag = dotToLine / rb.velocity.magnitude * drag;
                if(Mathf.Abs(linearDrag) < Mathf.Abs(dotToLine)){
                    rb.velocity = rb.velocity + new Vector2(-input.normalized.y,input.normalized.x) * linearDrag;
                }else{
                    rb.velocity = (input.normalized.x*rb.velocity.x + input.normalized.y*rb.velocity.y) * input.normalized;
                }
            }
            
        }else{
            slowDown = true;
            Vector2 dragVec = rb.velocity.normalized * drag;
            if(rb.velocity.magnitude > dragVec.magnitude){
                rb.velocity = rb.velocity - dragVec;
            }else{
                rb.velocity = Vector2.zero;
            }
            slowDown = false;
        }
        speed = rb.velocity.magnitude;
    }

    void armorCtrl(){
        rightShoulderArmor.enabled = false;
        leftShoulderArmor.enabled = false;
        front_backShoulderArmor.enabled = false;
        frontRightShoulderArmor.enabled = false;
        frontLeftShoulderArmor.enabled = false;

        switch(Dir){
            case 0://right
                rightShoulderArmor.enabled = true;
                break;
            case 4://left
                leftShoulderArmor.enabled = true;
                break;
            case 5://frontLeft
                frontLeftShoulderArmor.enabled = true;
                break;
            case 6://front
                front_backShoulderArmor.enabled = true;
                break;
            case 7://frontRight
                frontRightShoulderArmor.enabled = true;
                break;
        }
    }

    void setAnimation(){
        switch (Dir){
            case 0://right
                anim.Play("right");
                cloakspRend.enabled = true;
                cloakAnim.Play("rightCloak");
                break;
            case 1://backRight
                anim.Play("backRight");
                cloakspRend.enabled = false;
                break;
            case 2://back
                anim.Play("back");
                cloakspRend.enabled = false;
                break;
            case 3://backLeft
                anim.Play("backLeft");
                cloakspRend.enabled = false;
                break;
            case 4://left
                anim.Play("left");
                cloakspRend.enabled = false;
                break;
            case 5://frontLeft
                anim.Play("frontLeft");
                cloakspRend.enabled = true;
                cloakAnim.Play("frontLeftCloak");
                break;
            case 6://front
                anim.Play("front");
                cloakspRend.enabled = true;
                cloakAnim.Play("frontCloak");
                break;
            case 7://frontRight
                anim.Play("frontRight");
                cloakspRend.enabled = true;
                cloakAnim.Play("frontRightCloak");
                break;
        }
    }
}
