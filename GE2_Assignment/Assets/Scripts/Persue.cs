using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persue : SteeringBehaviour
{
    public Boid target;
    Vector3 targetPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override Vector3 Calculate()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        float time = dist / boid.maxSpeed;

        targetPos = target.transform.position + (target.velocity * time);

        //return boid.SeekForce(targetPos); 
        return boid.ArriveForce(targetPos); 
    }
       
}
