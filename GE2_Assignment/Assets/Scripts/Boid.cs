using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();

    public Vector3 force = Vector3.zero;
    public Vector3 accel = Vector3.zero;
    public Vector3 velocity = Vector3.zero;

    public float mass = 1;

    [Range(0.0f, 10.0f)]
    public float damping = 0.01f;

    [Range(0.0f, 10.0f)]
    public float banking = 0.01f;
    public float maxSpeed = 5.0f;
    public float maxForce = 10.0f;

    //public bool seekEnabled = true;
    //public Transform seekTargetTransform;
    //public Vector3 seekTarget;
    //public bool arriveEnabled = true;
    //public Transform arriveTargetTransform;
    //public Vector3 arriveTarget;
    //public float slowingDistance = 50;

    //public Path path;
    //public bool pathFollowingEnabled = false;
    //public float waypointDistance = 3;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + velocity);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + accel);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + force * 10);

    }
    // Start is called before the first frame update
    void Start()
    {
        SteeringBehaviour[] behaviours = GetComponents<SteeringBehaviour>();
        foreach (SteeringBehaviour b in behaviours)
        {
            this.behaviours.Add(b);
        }
    }

    public Vector3 SeekForce(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maxSpeed;
        return desired - velocity;
    }

    public Vector3 ArriveForce(Vector3 target, float slowingDistance = 40.0f)
    {
        Vector3 toTarget = target - transform.position;
        float dist = toTarget.magnitude;
        if(dist > 0)
        {
            float ramped = maxSpeed * (dist / slowingDistance);
            float clamped = Mathf.Min(ramped, maxSpeed);
            Vector3 desired = clamped * (toTarget / dist);

            return desired - velocity;
        }
        else
        {
            return Vector3.zero;
        }
    }
    Vector3 Calculate()
    {
        force = Vector3.zero;
        foreach(SteeringBehaviour b in behaviours)
        {
            if (b.isActiveAndEnabled)
            {
                force += b.Calculate() * b.weight;
                float f = force.magnitude;
                if(f >= maxForce)
                {
                    force = Vector3.ClampMagnitude(force, maxForce);
                    break;
                }
            }
        }
        return force;
    }/*
    public Vector3 PathFollow()
    {
        Vector3 nextWaypoint = path.NextWaypoint();
        if(!path.looped && path.IsLast())
        {
            return Arrive(nextWaypoint);
        }
        else
        {
            if(Vector3.Distance(transform.position, nextWaypoint) < waypointDistance)
            {
                path.AdvanceToNext();
            }
            return Seek(nextWaypoint);
        }
    }
    public Vector3 Seek(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        Vector3 desired = toTarget.normalized * maxSpeed;
        return(desired- velocity);
    }
    public Vector3 Arrive(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        float dist = toTarget.magnitude;
        float ramped = (dist/slowingDistance) * maxSpeed;
        float clamped = Mathf.Min(ramped, maxSpeed);
        Vector3 desired = (toTarget / dist) * clamped;
        return desired - velocity;
    }
    */
    // Update is called once per frame
    void Update()
    {
        force = Calculate();
        accel = force / mass;
        velocity += accel * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        if (velocity.magnitude > 0)
        {
            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (accel * banking), Time.deltaTime * 3.0f);
            transform.LookAt(transform.position + velocity, tempUp);
            transform.position += velocity * Time.deltaTime;
            velocity *= (1.0f - (damping * Time.deltaTime));
        }
    }
}
