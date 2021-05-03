using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeStation : MonoBehaviour
{
    // Start is called before the first frame update
    public float fuseTime = 3.0f;
    public float explodeTime = 6.0f;
    public GameObject explodePrefab;
    void Start()
    {
        //Invoke("Explode", fuseTime);
        Instantiate(explodePrefab);
        Destroy(gameObject, fuseTime);
        Destroy(explodePrefab, explodeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void Explode()
    {
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.main.duration);
    }*/
}
