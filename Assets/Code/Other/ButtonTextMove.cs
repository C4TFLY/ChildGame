using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonTextMove : MonoBehaviour {

    private RectTransform textTransform;

    private void Start()
    {
        textTransform = transform.GetChild(0).GetComponent<RectTransform>();
    }

    public void PressText()
    {
        textTransform.anchoredPosition = new Vector2(0, 0);
    }

    public void UnPressText()
    {
        textTransform.anchoredPosition = new Vector2(0, 5);
    }

    public void SecondaryPressText()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //textTransform.anchoredPosition = new Vector2(0,0);
        }
    }
}
