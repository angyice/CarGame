using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinishPointReload : MonoBehaviour
{
    public float timeToWaitUntilReload = 5f;
    public string sceneNameToLoad;

    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            Invoke("reLoad", timeToWaitUntilReload);
        }

    }

    void reLoad()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }

}
