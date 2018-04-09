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
    [TextArea] public string otherError;

    private Dictionary<string, string> localizedText;
    private bool isReady = false;
    private string missingTextString = "Localized text not found.";
	
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
            Debug.LogError($"Cannot find localization file '{fileName}' at '{filePath}'.");
            errorText.text = localeNotFoundError + lmm.selectedLanguageIndex;
        }


    }

    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;

        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        return result;
    }

    public bool IsReady()
    {
        return isReady;
    }
}
