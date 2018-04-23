using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    public float maxWidth = 930f;
    public PlayerSize sizeComponent;

    private static float sizeIncrease = 0;
    private RectTransform fillerImg;
    private static RectTransform fImg;
    private static float mWidth;

    private void Start()
    {
        sizeIncrease = maxWidth / sizeComponent.winScore;
        fillerImg = GetComponent<RectTransform>();
        mWidth = maxWidth;
        fImg = fillerImg;
    }

    public static void UpdateFiller(int amount = 1)
    {
        fImg.sizeDelta += new Vector2(sizeIncrease * amount, 0);
        if (fImg.sizeDelta.x > mWidth)
        {
            fImg.sizeDelta = new Vector2(mWidth, fImg.sizeDelta.y);
        }
    }

    private void test()
    {

    }

}
