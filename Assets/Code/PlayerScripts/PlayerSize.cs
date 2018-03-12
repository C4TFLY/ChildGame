using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour {

    public static int size = 1;
    public int[] sizeThresholds;

    public static int Size { get { return size; } }

    private float scaleIncrease;

    private void Start()
    {
        scaleIncrease = 2f / sizeThresholds.Length;
    }

    public void SizeIncrease()
    {
        if (size <= sizeThresholds.Length)
        {
            if (Scoring.PlayerScore > sizeThresholds[size - 1])
            {
                size++;
                transform.localScale = new Vector3(transform.localScale.x + scaleIncrease,
                                                    transform.localScale.y + scaleIncrease,
                                                    transform.localScale.z);
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
