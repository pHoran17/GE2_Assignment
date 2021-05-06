using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : SteeringBehaviour
{
    public Path path;
    Vector3 nextWaypoint;
    public Transform target1;
    public Transform target2;
    public float waypointDistance = 5;
    public float approachRange = 50;

    public void OnDrawGizmos()
    {
        if(isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, nextWaypoint);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("Range1: " + Vector3.Distance(transform.position, target1.position));
        print("Range2: " + Vector3.Distance(transform.position, target2.position));
    }

    public override Vector3 Calculate()
    {
        nextWaypoint = path.NextWaypoint();
        if(Vector3.Distance(transform.position, nextWaypoint) < waypointDistance)
        {
            if(Vector3.Distance(transform.position, target1.position) < approachRange)
            {
                //return boid.SeekForce(target1.position);
                transform.LookAt(target1.position);
                return boid.ArriveForce(target1.position);
            }
            else if(Vector3.Distance(transform.position, target2.position) < approachRange)
            {
                //return boid.SeekForce(target2.position);
                transform.LookAt(target2.position);
                return boid.ArriveForce(target2.position);
            }
            else
            {
                path.AdvanceToNext();
            }
            
        }
        if(!path.looped && path.IsLast())
        {
            //return boid.ArriveForce(nextWaypoint);
            if(Vector3.Distance(transform.position, target1.position) < approachRange)
            {
                //return boid.SeekForce(target1.position);
                transform.LookAt(target1.position);
                return boid.SeekForce(target1.position);
            }
            else if(Vector3.Distance(transform.position, target2.position) < approachRange)
            {
                //return boid.SeekForce(target2.position);
                transform.LookAt(target2.position);
                return boid.ArriveForce(target2.position);
            }
            else
            {
                return boid.ArriveForce(nextWaypoint);
            }
        }
        else
        {
            return boid.SeekForce(nextWaypoint);
        }
    }
}
