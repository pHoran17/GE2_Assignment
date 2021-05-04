﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : SteeringBehaviour
{
    public Vector3 targetPosition = Vector3.zero;
    public float slowingDistance = 15.0f;

    public GameObject targetGameObject = null;
    
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + force * 100);
    }

    public override Vector3 Calculate()
    {
        Vector3 force = boid.ArriveForce(targetPosition, slowingDistance);
        return force;
    }

    // Update is called once per frame
    void Update()
    {
        if(targetGameObject != null)
        {
            targetPosition = targetGameObject.transform.position;
        }
    }
}
