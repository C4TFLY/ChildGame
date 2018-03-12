using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour {

    private static int playerScore = 0;
    public static int PlayerScore { get { return playerScore; } }

    public void Score(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyFish") && Player.state == PlayerState.ALIVE)
        {

            GameObject enemy = collision.gameObject;
            Destroy(enemy);
            playerScore += enemy.GetComponent<EnemyFish>().properties.value;
            UIManager.UpdateText();
        }
    }

}
