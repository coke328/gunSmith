using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPool : MonoBehaviour
{
    public static bulletPool SharedInstance;
    public List<GameObject> pooledBullets;
    public int amountToPool;

    void Awake(){
        SharedInstance = this;
    }
    public void setup(GameObject bullet,int poolCnt)
    {

        pooledBullets = new List<GameObject>();
        GameObject tmp;
        for(int i=0; i<poolCnt; i++){
            tmp = Instantiate(bullet);
            tmp.SetActive(false);
            pooledBullets.Add(tmp);
        }
        amountToPool = poolCnt;
    }

    public void addBullet(GameObject bullet,int poolCnt){
        GameObject tmp;
        for(int i=0; i<poolCnt; i++){
            tmp = Instantiate(bullet);
            tmp.SetActive(false);
            pooledBullets.Add(tmp);
        }
        amountToPool += poolCnt;

    }

    public GameObject GetPooledBullet(){
        for(int i=0; i<amountToPool; i++){
            if(!pooledBullets[i].activeInHierarchy){
                return pooledBullets[i];
            }
        }
        return null;
    }
    public bool activeBullet(Vector2 pos,float r){
        GameObject bullet = bulletPool.SharedInstance.GetPooledBullet();
        if(bullet != null){
            bullet.transform.position = new Vector3(pos.x,pos.y,0);
            bullet.transform.eulerAngles = new Vector3(0,0,r);
            bullet.SetActive(true);
            return true;
        }else{
            return false;
        }
    }
}
