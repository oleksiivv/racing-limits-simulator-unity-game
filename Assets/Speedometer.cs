using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Image arrow;
    public Text speed;
    public Text totalKilometers;

    void Start(){
        StartCoroutine(startGame());
    }

    void Update(){
        arrow.transform.eulerAngles = new Vector3(0, 0, (-CarMove.speed + 5) * 65 - 90);

        var speedval = (int)((CarMove.speed - 1) * 70 + 20);

        speedval = speedval > 0 ? speedval : 0;

        speed.text = speedval.ToString();
        
        if(speedval == 0)
        {
            arrow.transform.eulerAngles = new Vector3(0, 0, 193);
        }
    }

    IEnumerator startGame(){
        while(arrow.transform.eulerAngles.z>170){
            arrow.transform.Rotate(0,0,5);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
