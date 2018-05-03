using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadManager : MonoBehaviour {

    public Slider progressSlider;
    public TextMeshProUGUI progressText;

	public void LoadLevel(int sceneIndex)
    {
        Debug.Log("Game starting.");
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    private IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        Debug.Log("Loading level...");

        while (!operation.isDone)
        {
            float loadProgress = Mathf.Clamp01(operation.progress / .9f);

            progressSlider.value = loadProgress;
            progressText.text = $"{loadProgress * 100}%";

            Debug.Log("Loaded: " + loadProgress);


            if (operation.progress >= 0.9f)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }

}
