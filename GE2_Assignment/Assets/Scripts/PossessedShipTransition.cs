using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PossessedShipTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Transform ship;
    public Transform player;
    bool isTargetsDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.FindWithTag("Target") && !GameObject.FindWithTag("Target2"))
        {
            print("Targets destroyed");
            isTargetsDestroy = true;
        }
        if(isTargetsDestroy)
        {
            float dist = Vector3.Distance(ship.position, player.position);
            print(dist);
            if(dist >= 200)
            {
                StartCoroutine(LoadBackgroundScene());
            }
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
