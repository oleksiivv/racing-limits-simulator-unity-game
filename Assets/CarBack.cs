using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBack : CarEnemy
{
    public override void init()
    {
    
        transform.position=new Vector3(Random.Range(0f,0.5f),transform.position.y,transform.position.z);

        speed=Random.Range(0.2f,0.4f);
    }

    // Update is called once per frame
    
}
