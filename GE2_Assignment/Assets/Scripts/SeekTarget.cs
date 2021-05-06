using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTarget : SteeringBehaviour
{
    public Transform target1;
    public Transform target2;
    //public Vector3 target1;
    //public Vector3 target2;
    bool inRange1 = false;
    bool inRange2 = false;
    public float approachRange = 50;

    public void OnDrawGizmos()
    {
        if(isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, target1.position);
            Gizmos.DrawLine(transform.position, target2.position);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target1.position) >= 50)
        {
            inRange1 = true;
        }
        else if(Vector3.Distance(transform.position, target2.position) >= 50)
        {
            inRange2 = true;
        }
        else
        {
            inRange1 = false;
            inRange2 = false;
            print("Dist to T1: " + Vector3.Distance(transform.position, target1.position));
            print("Dist to T2: " + Vector3.Distance(transform.position, target2.position));
        }
    }

    public override Vector3 Calculate()
    {
        
        
        if(inRange1)
        {
            return boid.SeekForce(target1.position);
        }
        else if(inRange2)
        {
            return boid.SeekForce(target2.position);
        }
        else
        {
            return Vector3.zero;
        }
    }
}
