﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public GameObject gameOverText;

    private static int playerScore = 0;
    public static int PlayerScore { get { return playerScore; } }

    private PlayerSize playerSize;
    private Player player;

    private void Start()
    {
        playerSize = GetComponent<PlayerSize>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (PlayerScore > playerSize.sizeThresholds[playerSize.sizeThresholds.Length - 1])
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
                Destroy(enemy);
                playerScore += enemy.GetComponent<EnemyFish>().properties.value;
                UIManager.UpdateText();
                playerSize.SizeIncrease();
            }
            else
            {
                player.Dead_Enter();
                gameOverText.SetActive(true);
                int difference = enemySize - PlayerSize.Size;
                string x = difference > 1 ? "sizes" : "size";
                gameOverText.GetComponent<Text>().text = $"You lost... You tried to eat a fish that was {difference} {x} bigger than you.";
            }
        }
    }

}
