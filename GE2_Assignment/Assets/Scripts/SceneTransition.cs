using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneToLoad;
    public Transform player;
    public Transform other;


    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Ship in zone");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    // && !other.isTrigger
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(other.position, player.position);
        print("Dist: " + dist);
        if(dist >= 350)
        {
            //SceneManager.LoadScene(sceneToLoad);
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
