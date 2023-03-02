using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBack : CarEnemy
{
    public override void init()
    {
    
        transform.position=new Vector3(Random.Range(-1.25f,1.25f),transform.position.y,transform.position.z);

        speed=Random.Range(0.4f,0.9f);
    }

    // Update is called once per frame
    
}
