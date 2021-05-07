using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<StateMachine>().ChangeState(new AttackState());
        GetComponent<StateMachine>().SetGlobalState(new Alive());
    }

    public void OnTriggerEnter(Collider collide)
    {
        if(collide.tag == "Bullet")
        {
            if(GetComponent<Fighter>().health > 0)
            {
                GetComponent<Fighter>().health --;
            }
            Destroy(collide.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
