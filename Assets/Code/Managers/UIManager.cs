using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
