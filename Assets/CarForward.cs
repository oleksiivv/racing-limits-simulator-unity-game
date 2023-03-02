using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarForward : CarEnemy
{
    // Start is called before the first frame update
    public override void init()
    {
        transform.position=new Vector3(Random.Range(-1.25f,1.25f),transform.position.y,transform.position.z);

        speed=Random.Range(0.8f,1.4f);
    }

    
}
