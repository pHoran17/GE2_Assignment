using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsText : MonoBehaviour
{
    public List<GameObject> texts = new List<GameObject>();
    public GameObject credits;
    public bool isComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        int count = credits.transform.childCount;
        //print(count);
        for(int i = 0; i < count; i++)
        {
            texts.Add(credits.transform.GetChild(i).gameObject);
        }
        StartCoroutine(ChangeText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeText()
    {
        foreach(GameObject g in texts)
        {
            g.GetComponent<Text>().enabled = true;
            yield return new WaitForSeconds(5);
            g.GetComponent<Text>().enabled = false;
        }
        isComplete = true;
    }
}
