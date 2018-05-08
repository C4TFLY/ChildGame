using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {
    
    public int score;

    private int playerScore = 0;
    private int fishEaten = 0;
    public int PlayerScore { get { return playerScore; } }
    public int FishEaten { get { return fishEaten; } }

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
        }
    }

    public void Score(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyFish") && Player.instance.state == PlayerState.ALIVE)
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
                if (Player.instance.playerSize.Size <= playerSize.sizeThresholds.Length)
                {
                    if (playerScore > playerSize.sizeThresholds[Player.instance.playerSize.Size - 1])
                    {
                        playerSize.SizeIncrease(1);
                    }
                }
            }
            else
            {
                player.Dead_Enter();
            }
        }
    }

#if UNITY_EDITOR
    public void AddScore(int amount)
    {
        playerScore += amount;
        ProgressBar.UpdateFiller(amount);
    }
#endif

}
