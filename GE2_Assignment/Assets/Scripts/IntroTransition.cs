using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroTransition : MonoBehaviour
{
    public string sceneToLoad;
    public float time;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(image.GetComponent<RawImage>().enabled)
        {
            if(time > 2000)
            {
                StartCoroutine(LoadBackgroundScene());
            }
            time = time + 1.0f;
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
