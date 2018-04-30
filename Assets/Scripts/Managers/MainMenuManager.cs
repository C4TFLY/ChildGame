using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quitting application.");
        Application.Quit();
    }

    public void StartGame()
    {
        Debug.Log("Game starting.");
        SceneManager.LoadScene("Main");
    }

    public void ChangeLanguage()
    {
        Debug.Log("Going back to language selection.");
        SceneManager.LoadScene(0);
        Destroy(LocalizationManager.instance.gameObject);
    }

}
