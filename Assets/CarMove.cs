using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMove : MonoBehaviour
{
    public Vector2 border;
    public Slider moveSlider;

    private float acceleration;



    public GameObject handler;
    public static float speed=1;

    void Start(){
        acceleration=0;
        speed=1;

        
    }

    void Update(){
        if(speed==0)return;

        if(Input.GetMouseButtonUp(0)){
            moveSlider.value=0;
        }
        else{
            if(acceleration<1)acceleration+=0.0125f*CarMove.speed;
        }

        if(Mathf.Abs(moveSlider.value)<0.1f){
            acceleration=0;
        }


        if(speed<2)speed+=0.001f;
        else if(speed>=2 && speed<3)speed+=0.00008f;
        else speed+=0.00002f;


        if((gameObject.transform.position.x<=0.5f && moveSlider.value >=0) || (gameObject.transform.position.x>=-0.5f && moveSlider.value <=0)){
            gameObject.transform.position+=new Vector3(moveSlider.value/2,0,0)*acceleration;
            transform.eulerAngles=new Vector3(0,moveSlider.value*60,0);
            handler.transform.eulerAngles=new Vector3(0,0,moveSlider.value*-1*60);
        }
        else{
            moveSlider.value=0;
            transform.eulerAngles=new Vector3(0,moveSlider.value*60,0);
            handler.transform.eulerAngles=new Vector3(0,0,moveSlider.value*-1*60);
        }

        
    }

}
