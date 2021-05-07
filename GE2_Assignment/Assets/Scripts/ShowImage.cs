using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImage : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject image;
    bool isEnabled = false;
    public float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(dialogue.GetComponent<HideDialogue>().isEnabled == false)
        {
            isEnabled = true;
            print(isEnabled);
            image.GetComponent<RawImage>().enabled = true;
            //image.SetActive(isEnabled);
        }
    }
}
