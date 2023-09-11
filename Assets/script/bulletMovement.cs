using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    public float bulletSpeed;
    public float damage;
    protected float finalBulletSpeed;
    protected float finalDamage;

    protected Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    virtual public void Update()
    {
        
    }

    public void setup(float speed,float d){
        bulletSpeed = speed;
        damage = d;
    }

    virtual public void bulletMove(){
        transform.Translate(bulletSpeed,0,0);
    }
    virtual public void bulletDamage(){

    }

    protected void destroy(){
        this.gameObject.SetActive(false);
    }
    public void setFinalValue(float bs,float d){
        finalBulletSpeed = bs;
        finalDamage = d;
    }
}
