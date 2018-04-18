using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public GameObject gameOverText;
    public int score;

    private static int playerScore = 0;
    private static int fishEaten = 0;
    public static int PlayerScore { get { return playerScore; } }
    public static int FishEaten { get { return fishEaten; } }

    private PlayerSize playerSize;
    private Player player;

    private void Start()
    {
        playerSize = GetComponent<PlayerSize>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        score = PlayerScore;
        if (PlayerScore >= playerSize.winScore)
        {
            player.Won_Enter();
            gameOverText.GetComponent<Text>().text = "You win!";
        }
    }

    public void Score(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyFish") && Player.state == PlayerState.ALIVE)
        {
            GameObject enemy = collision.gameObject;
            int enemySize = enemy.GetComponent<EnemyFish>().properties.size;
            if (playerSize.CheckSize(enemySize))
            {
                int enemyVal = enemy.GetComponent<EnemyFish>().properties.value;
                Destroy(enemy);
                playerScore += enemyVal;
                fishEaten += 1;
                ProgressBar.UpdateFiller(enemyVal);
                UIManager.UpdateText();
                if (playerSize.Size <= playerSize.sizeThresholds.Length)
                {
                    if (playerScore > playerSize.sizeThresholds[playerSize.Size - 1])
                    {
                        playerSize.SizeIncrease(1);
                    }
                }
            }
            else
            {
                player.Dead_Enter();
                gameOverText.SetActive(true);
                int difference = enemySize - playerSize.Size;
                string x = difference > 1 ? "sizes" : "size";
                gameOverText.GetComponent<Text>().text = $"You lost... You tried to eat a fish that was {difference} {x} bigger than you.";
            }
        }
    }

#if UNITY_EDITOR
    public void AddScore(int amount)
    {
        playerScore += amount;
    }
#endif

}
