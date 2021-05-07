using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursue : SteeringBehaviour
{
    public Boid target;
    Vector3 targetPos;
    Vector3 worldTarget;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
        offset = Quaternion.Inverse(target.transform.rotation) * offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override Vector3 Calculate()
    {
        worldTarget = target.transform.TransformPoint(offset);
        float dist = Vector3.Distance(transform.position, worldTarget);
        float time = dist/boid.maxSpeed;
        targetPos = worldTarget + (target.velocity * time);
        return boid.ArriveForce(targetPos);
    }
}
