using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManager : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quitting application.");
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void StartGame()
    {
        Debug.Log("Game starting.");
        //LoadManager.load
    }

    public void ChangeLanguage()
    {
        Debug.Log("Going back to language selection.");
        SceneManager.LoadScene(0);
        Destroy(LocalizationManager.instance.gameObject);
    }

}
