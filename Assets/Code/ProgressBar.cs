using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    public float maxWidth = 930f;
    public PlayerSize sizeComponent;

    private float sizeSpacing = 0;
    private static float sizeIncrease = 0;
    private static RectTransform fillerImg;

    private void Start()
    {
        sizeSpacing = maxWidth / sizeComponent.sizeThresholds.Length;
        sizeIncrease = sizeSpacing / (sizeComponent.sizeThresholds[sizeComponent.Size] - sizeComponent.sizeThresholds[sizeComponent.Size - 1]);
        fillerImg = GetComponent<RectTransform>();
    }

    public static void UpdateFiller(int amount)
    {
        fillerImg.sizeDelta += new Vector2(sizeIncrease * amount, 0);
    }

}
