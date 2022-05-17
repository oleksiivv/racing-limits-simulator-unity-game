using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarForward : CarEnemy
{
    // Start is called before the first frame update
    public override void init()
    {
        transform.position=new Vector3(Random.Range(-0.5f,0f),transform.position.y,transform.position.z);

        speed=Random.Range(0.6f,0.8f);
    }

    
}
