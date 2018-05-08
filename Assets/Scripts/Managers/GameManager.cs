using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public Player player;

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

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if (p)
        {
            player = p.GetComponent<Player>();
        }

    }

    public IEnumerator DisplayObjectAfterDelay(GameObject objectToDisplay, float delay = 3f)
    {
        yield return new WaitForSeconds(delay);
        objectToDisplay.SetActive(true);
    }
}
