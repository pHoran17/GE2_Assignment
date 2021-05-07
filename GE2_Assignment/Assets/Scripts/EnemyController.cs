using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //EnemyState _currentState;
    public float maxSpeed = 15.0f;
    public float attackRange = 30.0f;
    public float evadeRange = 40.0f;
    GameObject player;
    private Vector3 direction;
    private Vector3 destination;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        /*if(GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player");
        }*/
        GetComponent<StateMachine>().ChangeState(new PatrolState());
        GetComponent<StateMachine>().SetGlobalState(new Alive());
        
    }


    public void OnTriggerEnter(Collider collide)
    {
        print(collide.tag);
        if(collide.tag == "Bullet")
        {
            print("Hit");
            if(GetComponent<Fighter>().health > 0)
            {
                GetComponent<Fighter>().health --;
            }
            Destroy(collide.gameObject);
            if(GetComponent<StateMachine>().currentState.GetType() != typeof(Dead))
            {
                GetComponent<StateMachine>().ChangeState(new DefendState());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*switch(_currentState)
        {
            case EnemyState.Wander:
            {
                if(!PlayerNear())
                {
                    Patrol();

                    transform.rotation = rotation;
                    transform.Translate(Vector3.forward * Time.deltaTime * maxSpeed);

                    break;
                }
                else
                {
                    _currentState = EnemyState.Evade;
                    break;
                }
            }
            case EnemyState.Evade:
            {
                break;
            }
            case EnemyState.Attack:
            {
                break;
            }
        }*/
    }
    /*
    private void Patrol()
    {
        Vector3 patrolDest = (transform.position + (transform.forward * 5f) + 
                            new Vector3(UnityEngine.Random.Range(-10f, 10f), 
                                        0f, 
                                        UnityEngine.Random.Range(-10f, 10f)));
        
        destination = new Vector3(patrolDest.x, 0f, patrolDest.z);
        direction = Vector3.Normalize(patrolDest - transform.position);
        direction = new Vector3(direction.x, 1f, direction.z);
        rotation = Quaternion.LookRotation(direction);
    }
    private bool PlayerNear()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < evadeRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    */

}

/*public enum EnemyState
{
    Wander,
    Evade,
    Attack
}*/
