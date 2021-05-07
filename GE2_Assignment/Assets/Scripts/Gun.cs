using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform player;
    public float attackRange = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < attackRange)
        {
            transform.LookAt(player);
            GameObject.Instantiate(bullet, transform.position + transform.forward * 2, transform.rotation);
        }
    }
}
