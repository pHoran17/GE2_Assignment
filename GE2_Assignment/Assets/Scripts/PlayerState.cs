using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Path path;
    public GameObject bullet;
    public float maxSpeed = 10.0f;
    public float attackRange = 10.0f;
    public float chaseRange = 30.0f;
    public float waypointDistance = 5;
    private Turret turret;
    private PState _currentState;
    private Vector3 direction;
    private Vector3 destination;
    private Quaternion rotation;

    [Range(0.0f, 10.0f)]
    public float damping = 0.01f;

    [Range(0.0f, 10.0f)]
    public float banking = 0.01f;

    
    //Doesnt change destination upon arrival
    public void OnDrawGizmos()
    {
        if(isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, destination);
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(_currentState)
        {
            case PState.Wander:
            {
                if(NeedDes())
                {
                     GetDest();
                }
                print("Next Destination: " + destination);
                //print("Dist to Path Node: " + Vector3.Distance(transform.position, destination));
                print("Dest Needed: " + NeedDes());
                //print("Current State: " + _currentState);
                transform.rotation = rotation;
                
                transform.Translate(Vector3.forward * Time.deltaTime * maxSpeed);

                //Code for checking for target
                var enemyTarget = CheckForEnemy();
                //print(enemyTarget);
                if(enemyTarget != null)
                {
                    turret = enemyTarget.GetComponent<Turret>();
                    _currentState = PState.Chase;
                }
                if(enemyTarget == null)
                {
                    turret = null;
                    _currentState = PState.Wander;
                }
                break;

            }
            case PState.Chase:
            {
                if(turret == null)
                {
                    _currentState = PState.Wander;
                    return;
                }
                transform.LookAt(turret.transform);
                transform.Translate(Vector3.forward * Time.deltaTime * maxSpeed);

                if(Vector3.Distance(transform.position, turret.transform.position) < attackRange)
                {
                     _currentState = PState.Attack;
                }
                break;
            }
            case PState.Attack:
            {
                if(turret != null)
                {
                    //Make bullet
                    GameObject.Instantiate(bullet, transform.position + transform.forward * 2, transform.rotation);
                    Destroy(turret.gameObject);
                    print("State: " + _currentState);
                    //_currentState = PState.Wander;
                }
                _currentState = PState.Wander;
                destination = Vector3.zero;
                break;
            }
        }
    }

    private void GetDest()
    {
        destination = path.NextWaypoint();
        direction = Vector3.Normalize(destination - transform.position);
        direction = new Vector3(direction.x, direction.y, direction.z);
        rotation = Quaternion.LookRotation(direction);
        if(Vector3.Distance(transform.position, destination) < waypointDistance)
        {
            print("Ship close to node");
            path.AdvanceToNext();
        }

    }
    private bool NeedDes()
    {
        if(destination == Vector3.zero)
        {
            return true;
        }
        var dist = Vector3.Distance(transform.position, destination);
        if(dist <= waypointDistance)
        {
            return true;
        }
        return false;
    }
    private Transform CheckForEnemy()
    {
        //Check for objects with Turret script in specified radius, set target if true
        float enemyRadius = 30.0f;
        //Only attacks one target due to and clause, change this
        if(GameObject.FindWithTag("Target") != null && GameObject.FindWithTag("Target2") != null)
        {
            GameObject turret1 = GameObject.FindWithTag("Target");
            GameObject turret2 = GameObject.FindWithTag("Target2");
            print("Turret1 pos: " + turret1.transform.position);
            if(Vector3.Distance(transform.position, turret1.transform.position) < enemyRadius && turret1 != null)
            {
                return turret1.transform;
            }
            else if(Vector3.Distance(transform.position, turret2.transform.position) < enemyRadius && turret2 != null)
            {
                return turret2.transform;
            }
            else
            {
                return null;
            }
        }
        else if(GameObject.FindWithTag("Target") != null)
        {
            GameObject turret1 = GameObject.FindWithTag("Target");
            if(Vector3.Distance(transform.position, turret1.transform.position) < enemyRadius && turret1 != null)
            {
                return turret1.transform;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}

public enum PState
{
    Wander,
    Chase,
    Attack
}
