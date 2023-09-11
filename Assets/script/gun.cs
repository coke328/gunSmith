using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{   
    public ScriptableObjectGunBody body;
    public ScriptableObjectBarrel barrel;
    public ScriptableObjectDot dot;
    public ScriptableObjectGrib grib;
    public ScriptableObjectHandGuard handGuard;
    public ScriptableObjectMag mag;
    public ScriptableObjectMuzzle muzzle;
    public ScriptableObjectReverse reverse;
    public ScriptableObjectTrigger trigger;
    public ScriptableObjectSpring spring;
    public float defaultSpread;
    public float moveSpread;
    public float zoomSpread;
    public float fireSpread;
    public float damage;
    public float semiFirerate;
    public float burstFirerate;
    public float autoFirerate;
    public float bulletSpeed;
    public float zoomRange;
    public float fireDelay;
    public float zoomScreenSize;
    public float ads;
    public int firemode;
    private SpriteRenderer bodySprd;
    private SpriteRenderer barrelSprd;
    private SpriteRenderer handGuardSprd;
    private SpriteRenderer dotSprd;
    private SpriteRenderer gribSprd;
    private SpriteRenderer magSprd;
    private SpriteRenderer muzzleSprd;
    private SpriteRenderer reverseSprd;
    public bool equiped;
    private Animation anim;
    private Transform t;
    private AnimationClip lastAnim;
    private defaultGun Gun;
    public int gunType = -1;
    public int bulletCnt;
    public bool reloading = false;
    private bulletMovement bulletScript;
    public bool fireAble = false;
    public int magSize;
    public float reloadTime;
    public float spread = 10f;
    public GameObject Player;

    enum gunT{
        defaultGun,//0
        shotGun,//1
    }

    void Start()
    {
        bodySprd = GetComponent<SpriteRenderer>();
        barrelSprd = transform.GetChild(0).GetComponent<SpriteRenderer>();
        handGuardSprd = transform.GetChild(1).GetComponent<SpriteRenderer>();
        dotSprd = transform.GetChild(2).GetComponent<SpriteRenderer>();
        gribSprd = transform.GetChild(3).GetComponent<SpriteRenderer>();;
        magSprd = transform.GetChild(4).GetComponent<SpriteRenderer>();
        muzzleSprd = transform.GetChild(5).GetComponent<SpriteRenderer>();
        reverseSprd = transform.GetChild(6).GetComponent<SpriteRenderer>();
        anim = GetComponent<Animation>();
        if(mag && bulletScript){
            bulletScript = mag.bullet.GetComponent<bulletMovement>();
        }

        t = GetComponent<Transform>();

        assemble();
        //equip();
    }

    // Update is called once per frame
    public void Update()
    {
        if(equiped && Gun != null && fireAble){

            if(Input.GetKeyDown(KeyCode.B)){
                changeFiremode();
            }else{
                Gun.mechanism(reloading);
            }
        }
        if(Input.GetKeyDown(KeyCode.R) && bulletCnt != mag.magSize){
            reloading = true;
            Invoke("reloadComplete",mag.reloadTime);
        }
    }

    void reloadComplete(){
        bulletCnt = mag.magSize;
        reloading = false;
    }
    
    void assemble(){
        fireAble = false;
        gunType = -1;

        if(lastAnim){
            anim.RemoveClip(lastAnim);
        }

        if(body){
            bodySprd.sprite = body.img;
            defaultSpread += body.defaultSpread;
            moveSpread += body.moveSpread;
            zoomSpread += body.zoomSpread;
            fireSpread += body.fireSpread;
            damage += body.damage;
            semiFirerate += body.semiFireRate;
            burstFirerate += body.burstFirerate;
            autoFirerate += body.autoFireRate;
            bulletSpeed += body.bulletSpeed;
            zoomRange += body.zoomRange;
            fireDelay += body.fireDelay;
            zoomScreenSize += body.zoomScreenSize;
            ads += body.ads;
            gunType = body.gunType;
        }
        if(barrel){
            barrelSprd.sprite = barrel.img;
            transform.GetChild(0).localPosition = new Vector3(body.barrelOffsetPos.x,body.barrelOffsetPos.y,0);
            defaultSpread += barrel.defaultSpread;
            moveSpread += barrel.moveSpread;
            zoomSpread += barrel.zoomSpread;
            fireSpread += barrel.fireSpread;
            damage += barrel.damage;
            bulletSpeed += barrel.bulletSpeed;
            ads += barrel.ads;

        }
        if(handGuard){
            handGuardSprd.sprite = handGuard.img;
            transform.GetChild(1).localPosition = new Vector3(body.HandGuardOffsetPos.x,body.HandGuardOffsetPos.y,0);
            defaultSpread += handGuard.defaultSpread;
            moveSpread += handGuard.moveSpread;
            zoomSpread += handGuard.zoomSpread;
            fireSpread += handGuard.fireSpread;
            ads += handGuard.ads;
        }
        if(dot){
            dotSprd.sprite = dot.img;
            transform.GetChild(2).localPosition = new Vector3(body.dotOffsetPos.x,body.dotOffsetPos.y,0);
            zoomSpread += dot.zoomSpread;
            zoomRange += dot.zoomRange;
            zoomScreenSize += dot.zoomScreenSize;
            ads += dot.ads;
        }
        if(grib){
            gribSprd.sprite = grib.img;
            if(handGuard){
                transform.GetChild(3).localPosition = new Vector3(body.HandGuardOffsetPos.x + handGuard.gribOffsetPos.x,body.HandGuardOffsetPos.y + handGuard.gribOffsetPos.y,0);
            }
            defaultSpread += grib.defaultSpread;
            moveSpread += grib.moveSpread;
            zoomSpread += grib.zoomSpread;
            fireSpread += grib.fireSpread;
            ads += grib.ads;
        }
        if(mag){
            magSprd.sprite = mag.img;
            transform.GetChild(4).localPosition = new Vector3(body.magOffsetPos.x,body.magOffsetPos.y,0);
            ads += mag.ads;
            bulletCnt = mag.magSize;
            magSize = mag.magSize;
            reloadTime = mag.reloadTime;

        }
        if(muzzle){
            muzzleSprd.sprite = muzzle.img;
            if(muzzle){
                transform.GetChild(5).localPosition = new Vector3(body.barrelOffsetPos.x + barrel.muzzleOffsetPos.x,body.barrelOffsetPos.y + barrel.muzzleOffsetPos.y,0);
            }
            defaultSpread += muzzle.defaultSpread;
            moveSpread += muzzle.moveSpread;
            zoomSpread += muzzle.zoomSpread;
            fireSpread += muzzle.fireSpread;
            bulletSpeed += muzzle.bulletSpeed;
            ads += muzzle.ads;
        }
        if(reverse){
            reverseSprd.sprite = reverse.img;
            transform.GetChild(6).localPosition = new Vector3(body.reverseOffsetPos.x,body.reverseOffsetPos.y,0);
            defaultSpread += reverse.defaultSpread;
            moveSpread += reverse.moveSpread;
            zoomSpread += reverse.zoomSpread;
            fireSpread += reverse.fireSpread;
            ads += reverse.ads;
        }
        if(trigger){
            fireDelay += trigger.fireDelay;
        }
        if(spring){
            semiFirerate += spring.semiFirerate;
            burstFirerate += spring.burstFirerate;
            autoFirerate += spring.autoFirerate;
        }
        if(bulletScript){
            damage += bulletScript.damage;
            bulletSpeed += bulletScript.bulletSpeed;
            bulletScript.setFinalValue(bulletSpeed,damage);
        }
        
        if(body && mag && bulletScript){
            fireAble = true;
        }

        anim.AddClip(body.animClip,"fireAnim");
        lastAnim = body.animClip;

        if(body.auto){
            firemode = 2;
        }else if(body.burst){
            firemode = 1;
        }else if(body.semi){
            firemode = 0;
        }

        switch(gunType){
            case (int)gunT.defaultGun:
                Gun = new defaultGun(defaultSpread,moveSpread,zoomSpread,fireSpread,damage,semiFirerate,burstFirerate,autoFirerate,ref bulletCnt,magSize,fireDelay,reloadTime,ref t,ref anim);
                break;
            case (int)gunT.shotGun:

                break;
        }
    }
    public void equip(){
        transform.parent = Player.transform.GetChild(1).transform.GetChild(0).transform;
        transform.localPosition = new Vector3(0,0,0);
        equiped = true;
    }
    void changeFiremode(){
        bool tmp = true;
        while(tmp){
            firemode++;
            if(firemode == 3){firemode = 0;}
            if(firemode == 0 && body.semi){tmp = false;}
            else if(firemode == 1 && body.burst){tmp = false;}
            else if(firemode == 2 && body.auto){tmp = false;}
        }
    }
    void playFireAnim(){
        if(!anim.isPlaying){
            anim.Play("fireAnim");
        }
    }
    void rotation(float r){
        transform.eulerAngles = new Vector3(0,0,r);
    }
}

public class defaultGun//gunType 0
{
    protected float defaultSpread;
    protected float moveSpread;
    protected float zoomSpread;
    protected float fireSpread;
    protected float damage;
    protected float semiFirerate;
    protected float burstFirerate;
    protected float autoFirerate;
    protected float bulletSpeed;
    protected float fireDelay;
    protected float reloadTime;
    protected int magSize;
    protected int firemode;
    protected int bulletCnt = new int();
    protected Animation anim;
    protected Transform tran;
    protected float delay = 0;
    protected bool chamberReloading = false;
    protected float chamberReloadT = 0;
    

    public defaultGun(float dSpread,float mSpread,float zSpread,float fSpread,float d,float sFirerate,float bFirerate,float aFirerate,ref int bCnt,int maxbullet,float fDelay,float rT,ref Transform t,ref Animation a){
        anim = a;
        tran = t;
        bulletCnt = bCnt;
        defaultSpread = dSpread;
        moveSpread = mSpread;
        zoomSpread = zSpread;
        fireSpread = fSpread;
        damage = d;
        semiFirerate = sFirerate;
        burstFirerate = bFirerate;
        autoFirerate = aFirerate;
        fireDelay = fDelay;
        reloadTime = rT;
        magSize = maxbullet;
    }
    public void mechanism(bool reloading){
        if(bulletCnt > 0 && !reloading){
            if(firemode == 0){

                semiFire();

            }else if(firemode == 1){

                burstFire();

            }else if(firemode == 2){

                autoFire();

            }
        }else{
            delay = 0;
        }
    }
    virtual protected void semiFire(){
        if(chamberReloadT >= semiFirerate){
            if(Input.GetMouseButton(0)){
                delay += Time.deltaTime;
            }else{
                delay = 0;
            }
            if(delay > fireDelay){
                
                bulletFire();
                
                chamberReloadT = 0;
                delay = 0;
            }
        }else {
            chamberReloadT += Time.deltaTime;
        }
    }
    virtual protected void burstFire(){

    }
    virtual protected void autoFire(){

    }
    protected void bulletFire(){
        Debug.Log("Fire");
        anim.Play("fireAnim");
        bulletCnt--;
    }
}
