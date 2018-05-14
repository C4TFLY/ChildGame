using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LocalizedText : MonoBehaviour {

    public string key;
    private TextMeshProUGUI text;

	void Start ()
    {
        text = GetComponent<TextMeshProUGUI>();

        if (LocalizationManager.instance)
        {
            Debug.Log($"Applying localized value for {gameObject.name} with key '{key}'.");
            string val = LocalizationManager.instance.GetLocalizedValue(key);
            if (val != "")
            {
                text.text = val;
            }
        }
        else
        {
            Scene indexZeroScene = SceneManager.GetSceneAt(0);
            Debug.LogError("No LocalizationManager instance exists! Did the game start in the right scene? (Error code 02)");
            Debug.Log("Build index zero is " + indexZeroScene.name);
        }
	}

    public void UpdateText(string key)
    {
        Debug.Log($"Applying localized value for {gameObject.name} with key '{key}'.");
        string val = LocalizationManager.instance.GetLocalizedValue(key);
        if (val != "")
        {
            text.text = val;
        }
    }
    
}
