using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPath : SteeringBehaviour
{
    public Path path;
    Vector3 nextWaypoint;
    public float waypointDistance = 5;

    void Start()
    {
        
    }


    public void OnDrawGizmos()
    {
        if(isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, nextWaypoint);
        }
    }

    public override Vector3 Calculate()
    {
        nextWaypoint = path.NextWaypoint();
        print(Vector3.Distance(transform.position, nextWaypoint));
        if(Vector3.Distance(transform.position, nextWaypoint) < waypointDistance)
        {
            print("Condition met");
            path.AdvanceToNext();
        }
        if(!path.looped && path.IsLast())
        {
            return boid.ArriveForce(nextWaypoint);
        }
        else
        {
            return boid.SeekForce(nextWaypoint);
        }
    }
}
