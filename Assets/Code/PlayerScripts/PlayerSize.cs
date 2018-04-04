using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour {

    public static int size = 1;
    public float smoothTime = 0.3f;
    public float winScore;
    public int[] sizeThresholds;

    public static int Size { get { return size; } }

    private float scaleIncrease;
    private bool changeScale = false;
    private float scaleYChange = 0.0f;
    private float scaleXChange = 0.0f;
    private Vector3 newScale, originalScale;

    private void Start()
    {
        scaleIncrease = 2f / sizeThresholds.Length;
        originalScale = newScale = new Vector3(transform.localScale.x,
                                transform.localScale.y,
                                transform.localScale.z);
    }

    private void Update()
    {
        float newScaleY = Mathf.SmoothDamp(transform.localScale.y, newScale.y, ref scaleYChange, smoothTime);
        float newScaleX = Mathf.SmoothDamp(transform.localScale.x, newScale.x, ref scaleXChange, smoothTime);
        transform.localScale = new Vector3(newScaleX,
                                            newScaleY,
                                            transform.localScale.z);
    }

    public void SizeIncrease()
    {
        if (size <= sizeThresholds.Length)
        {
            if (Scoring.PlayerScore > sizeThresholds[size - 1])
            {
                changeScale = true;
                size++;
                newScale = new Vector3(originalScale.x + (scaleIncrease * (size - 1)),
                                        originalScale.y + (scaleIncrease * (size - 1)),
                                        originalScale.z);
            }
        }
    }

    /// <summary>
    /// Returns true if the player is larger than the enemy
    /// </summary>
    /// <param name="enemySize">The enemy's size</param>
    /// <returns></returns>
    public bool CheckSize(int enemySize)
    {
        return size > enemySize;
    }

}
