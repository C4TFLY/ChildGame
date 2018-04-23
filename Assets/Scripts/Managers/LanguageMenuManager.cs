using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageMenuManager : MonoBehaviour {

    public int selectedLanguageIndex = 0;
    public Language[] languages;

    [Header("Container")]
    public Image flagContainer;
    public TextMeshProUGUI languageNameContainer;

    private void Start()
    {
        flagContainer.sprite = languages[0].flag;
        languageNameContainer.text = languages[0].language;
    }

    private void Update()
    {
        print(languageNameContainer.GetComponent<RectTransform>().position);
    }

    public void NextButton()
    {
        if (selectedLanguageIndex == languages.Length - 1)
        {
            selectedLanguageIndex = 0;
        }
        else
        {
            selectedLanguageIndex++;
        }

        flagContainer.sprite = languages[selectedLanguageIndex].flag;
        languageNameContainer.text = languages[selectedLanguageIndex].language;
    }

    public void PrevButton()
    {
        if (selectedLanguageIndex == 0)
        {
            selectedLanguageIndex = languages.Length - 1;
        }
        else
        {
            selectedLanguageIndex--;
        }

        flagContainer.sprite = languages[selectedLanguageIndex].flag;
        languageNameContainer.text = languages[selectedLanguageIndex].language;
    }
}

[System.Serializable]
public class Language
{
    public Sprite flag;
    public string language;
    public string localeFile;
}
