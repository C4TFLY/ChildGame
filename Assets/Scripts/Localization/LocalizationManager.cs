using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class LocalizationManager : MonoBehaviour {

    public static LocalizationManager instance;
    public LanguageMenuManager lmm;

    [Header("Error handling")]
    public TextMeshProUGUI errorText;
    [TextArea] public string localeNotFoundError;

    private Dictionary<string, string> localizedText;
    private bool isReady = false;
	
	void Awake ()
    {
        errorText.text = "";
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
	
    public void LoadLocalizedText()
    {
        localizedText = new Dictionary<string, string>();
        string fileName = lmm.languages[lmm.selectedLanguageIndex].localeFile;
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        Debug.Log($"Trying to load {lmm.languages[lmm.selectedLanguageIndex]} at {filePath}");

        if (File.Exists(filePath))
        { 
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }

            Debug.Log("Data loaded. Dictionary contains: " + localizedText.Count + " entries.");
            isReady = true;
        }
        else
        {
            Debug.LogError($"Cannot find localization file '{fileName}' at '{filePath}'. Error code 01{lmm.selectedLanguageIndex}");
            errorText.text = localeNotFoundError + lmm.selectedLanguageIndex;
        }


    }

    public string GetLocalizedValue(string key)
    {
        if (localizedText.ContainsKey(key))
        {
            return localizedText[key];
        }
        else
        {
            Debug.LogError($"Could not find localization key '{key}'.");
        }
        return "";
    }

    public bool ValueExistsForKey(string key)
    {
        if (localizedText.ContainsKey(key))
        {
            return true;
        }
        return false;
    }

    public bool IsReady()
    {
        return isReady;
    }
}
