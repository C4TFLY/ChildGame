using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour {

    [SerializeField] private int playerScore = 0;
    public int PlayerScore { get { return playerScore; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyFish"))
        {
            GameObject enemy = collision.gameObject;
            Destroy(enemy);
            playerScore += enemy.GetComponent<EnemyFish>().properties.value;
        }
    }
}
