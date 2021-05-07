using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExitPath : SteeringBehaviour
{
    public Path path;
    GameObject[] enemies;
    Vector3 nextWaypoint;
    public float waypointDistance = 5;
    //bool isSafe = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*enemies = GameObject.FindGameObjectsWithTag("Enemy")
        foreach(GameObject g in enemies)
        {
            if(g.GetComponent<StateMachine>().currentState.GetType() == typeof(Dead))
            {

            }
        }*/
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
        /*if(isSafe)
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
        else
        {

        }*/
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
