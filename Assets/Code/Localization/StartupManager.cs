using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour {

	private IEnumerator Start ()
    {
        while (!LocalizationManager.instance.IsReady())
        {
            yield return null;
        }

        SceneManager.LoadScene("Main");
	}

}
