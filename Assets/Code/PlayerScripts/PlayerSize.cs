using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Scoring))]
public class PlayerSize : MonoBehaviour {

    public int size = 1;
    public int[] sizeThresholds;
    
    private Scoring scoring;

    private void Start()
    {
        scoring = GetComponent<Scoring>();
    }

    public void SizeCheck()
    {
        if ((size - 1 <= sizeThresholds.Length) && Scoring.PlayerScore > sizeThresholds[size - 1])
        {
            size++;
        }
    }

}
