using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExitPath : SteeringBehaviour
{
    public Path path;
    Vector3 nextWaypoint;
    public float waypointDistance = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
