using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour {

    public float smoothTime = 0.3f;
    public int winScore;
    public int[] sizeThresholds;
    public float maxSizeScale = 3f;

    public static int Size { get { return playerSize; } }

    [SerializeField] private static int playerSize = 1;
    private float scaleIncrease;
    private float scaleYChange = 0.0f;
    private float scaleXChange = 0.0f;
    private Vector3 newScale, originalScale, wantedScale;

    private void Start()
    {
        scaleIncrease = (maxSizeScale - transform.localScale.x) / sizeThresholds.Length;
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

    public void SizeIncrease(int amount)
    {
            playerSize += amount;
            newScale = new Vector3(originalScale.x + (scaleIncrease * (playerSize - 1)),
                                    originalScale.y + (scaleIncrease * (playerSize - 1)),
                                    originalScale.z);
    }

#if UNITY_EDITOR
    public void SetSize(int size)
    {
        playerSize = size;
        newScale = new Vector3(originalScale.x + (scaleIncrease * size),
                                originalScale.y + (scaleIncrease * size),
                                originalScale.z);
    }
#endif

    /// <summary>
    /// Returns true if the player is larger than the enemy
    /// </summary>
    /// <param name="enemySize">The enemy's size</param>
    /// <returns></returns>
    public bool CheckSize(int enemySize)
    {
        return playerSize > enemySize;
    }

}
