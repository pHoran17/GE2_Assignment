using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceBattleExit : MonoBehaviour
{
    public Transform ship;
    public GameObject endDialogue;
    public string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, ship.position);
        if(dist < 350)
        {
            endDialogue.GetComponent<HideDialogue>().isEnabled = true;
        }
        if(dist < 300)
        {
            StartCoroutine(LoadBackgroundScene());
        }
    }

    IEnumerator LoadBackgroundScene()
    {
        AsyncOperation bgLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        while(!bgLoad.isDone)
        {
            yield return null;
        }
    }
}
