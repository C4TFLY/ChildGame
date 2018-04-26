using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalizedText : MonoBehaviour {

    public string key;

	void Start ()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        if (LocalizationManager.instance)
        {
            Debug.Log($"Applying localized value for {text.gameObject.name} with key '{key}'.");
            string val = LocalizationManager.instance.GetLocalizedValue(key);
            if (val != "")
            {
                text.text = val;
            }
        }
        else
        {
            Debug.LogError("No LocalizationManager instance exists! Did the game start in the right scene?");
            Debug.Log("Scene loaded: " + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
	}
}
