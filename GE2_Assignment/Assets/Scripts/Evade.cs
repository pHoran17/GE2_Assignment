using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : SteeringBehaviour
{
    public GameObject targetGameObject = null;
    public Vector3 target = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public override Vector3 Calculate()
    {
        return - boid.SeekForce(target);
    }
    // Update is called once per frame
    void Update()
    {
        if(targetGameObject != null)
        {
            target = targetGameObject.transform.position;
        }
    }
}
