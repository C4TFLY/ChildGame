using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadManager : MonoBehaviour {

    public Slider progressSlider;
    public TextMeshProUGUI progressText;
    public GameObject loadingText;

	public void LoadLevel(int sceneIndex)
    {
        Debug.Log("Game starting.");
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    private IEnumerator LoadAsynchronously (int sceneIndex)
    {
        float loadProgress = 0;
        bool informedUser = false;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        Debug.Log("Loading level...");

        while (!operation.isDone)
        {
            float progClamped = Mathf.Clamp01(operation.progress / .9f);
            if (loadProgress != progClamped)
            {
                loadProgress = progClamped;
                Debug.Log("Loaded: " + loadProgress);
            }

            progressSlider.value = loadProgress;
            progressText.text = $"{loadProgress * 100}";


            if (operation.progress >= 0.9f && !informedUser)
            {
                UpdateLoadingText();
                informedUser = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    private void UpdateLoadingText()
    {
        loadingText.GetComponent<LocalizedText>().UpdateText("loading_complete");
    }

}
