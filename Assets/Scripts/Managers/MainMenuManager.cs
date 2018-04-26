using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public TextMeshProUGUI masterVolumeLabel;
    public Slider masterVolumeSlider;

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

    private void Update()
    {
        if (masterVolumeLabel.gameObject.activeInHierarchy)
        {
            float roundedVal = Round(masterVolumeSlider.value, 2);
            string roundedStr = roundedVal.ToString().Replace(",", ".");
            
            masterVolumeLabel.text = roundedVal == 1 ? "1.00" : roundedVal == 0 ? "0.00" : roundedStr;
        }
    }

    private float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, digits);
        return Mathf.Round(value * mult) / mult;
    }

}
