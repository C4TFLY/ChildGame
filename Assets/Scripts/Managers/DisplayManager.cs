using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayManager : MonoBehaviour {

    public static DisplayManager instance;

    public Resolution[] resolutions;
    public int currentResolutionIndex;
    public bool fullscreen = true;
    public int pendingWidth, pendingHeight, pendingRefreshRate;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


        resolutions = Screen.resolutions;
        pendingHeight = Screen.currentResolution.height;
        pendingWidth = Screen.currentResolution.width;
        pendingRefreshRate = Screen.currentResolution.refreshRate;
    }

    public void SetResolution()
    {
        Screen.SetResolution(pendingWidth, pendingHeight, fullscreen, pendingRefreshRate);
    }

    public void ApplyChanges()
    {
        SetResolution();
    }
}
