using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDialogue : MonoBehaviour
{
    public GameObject dialogue;
    public bool isEnabled = true;
    public float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 1200.0f)
        {
            isEnabled = false;
            dialogue.SetActive(isEnabled);
        }
        time = time + 1.0f;
        
    }
}
