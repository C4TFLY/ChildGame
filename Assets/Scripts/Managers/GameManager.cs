using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator DisplayObjectAfterDelay(GameObject objectToDisplay, float delay = 3f)
    {
        yield return new WaitForSeconds(delay);
        objectToDisplay.SetActive(true);
    }
}
