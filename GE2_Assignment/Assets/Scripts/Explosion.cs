using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float fuseTime = 3.0f;
    public float explodeTime = 6.0f;
    public GameObject explodePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(explodePrefab);
        Destroy(explodePrefab, explodeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
