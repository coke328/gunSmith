using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayGun : MonoBehaviour
{
    public Transform gunHold;
    public playerMovement pm;
    private Renderer myRenderer;
    private int dir = 0;
    private Renderer leftArmRender;

    // Start is called before the first frame update
    void Start()
    {
        if(myRenderer == null){
            myRenderer = GetComponent<Renderer>();
        }
        leftArmRender = transform.GetChild(0).GetComponent<Renderer>();

        setSortingOrder();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = gunHold.position;

        if(dir != pm.Dir){
            setSortingOrder();
            dir = pm.Dir;
        }

    }
    void setSortingOrder(){
        switch(pm.Dir){
            case 0://right
                myRenderer.sortingOrder = 11;
                leftArmRender.sortingOrder = 5;
                break;
            case 1://backRight
                myRenderer.sortingOrder = 5;
                leftArmRender.sortingOrder = 5;
                break;
            case 2://back
                myRenderer.sortingOrder = 5;
                leftArmRender.sortingOrder = 5;
                break;
            case 3:
                myRenderer.sortingOrder = 5;
                leftArmRender.sortingOrder = 5;
                break;
            case 4:
                myRenderer.sortingOrder = 5;
                leftArmRender.sortingOrder = 11;
                break;
            case 5:
                myRenderer.sortingOrder = 11;
                leftArmRender.sortingOrder = 12;
                break;
            case 6:
                myRenderer.sortingOrder = 12;
                leftArmRender.sortingOrder = 11;
                break;
            case 7:
                myRenderer.sortingOrder = 12;
                leftArmRender.sortingOrder = 11;
                break;
            }
    }
}
