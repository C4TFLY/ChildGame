using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using System;
using System.Text.RegularExpressions;
#endif

public class UIManager : MonoBehaviour {

    public Text scoreText;
    private static Text sText;

    private void Awake()
    {
        sText = scoreText;
        scoreText.text = "Score: 0";
    }

    public static void UpdateText()
    {
        sText.text = $"Score: {Scoring.PlayerScore}";
    }

#if UNITY_EDITOR
    private string sizeInput = "1";
    private string scoreInput = "100";
    public PlayerSize playerSize;
    public Scoring scoring;
    void OnGUI()
    {
        GUI.Label(new Rect(10, 40, 50, 20), "Size: ");
        GUI.Label(new Rect(10, 70, 50, 20), "Score: ");
        sizeInput = GUI.TextField(new Rect(50, 40, 50, 20), sizeInput, 25);
        scoreInput = GUI.TextField(new Rect(50, 70, 50, 20), scoreInput, 25);
        sizeInput = Regex.Replace(sizeInput, @"[^0-9.]", "");
        if (GUI.Button(new Rect(10, 100, 50, 20), "Apply"))
        {
            playerSize.SetSize(Int32.Parse(sizeInput));
            scoring.AddScore(Int32.Parse(scoreInput));
        }
    }
#endif
}
