using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum PlayerState
{
    ALIVE,
    DEAD,
    WON
}

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Scoring))]
[RequireComponent(typeof(PlayerSize))]
public class Player : MonoBehaviour {

    public static PlayerState state = PlayerState.ALIVE;
    public SpriteRenderer playerSprite;
    public GameObject winText, loseText, replayPrompt;

    private PlayerMovement playerMovement;
    private Scoring scoring;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        scoring = GetComponent<Scoring>();
    }

    void Update () {
        switch (state)
        {
            case PlayerState.ALIVE:
                Alive_Update();
                break;
            case PlayerState.DEAD:
                Dead_Update();
                break;
            case PlayerState.WON:
                Won_Update();
                break;
        }
    }

    private void Alive_Update()
    {
        playerMovement.MovePlayer();
    }

    private void Dead_Update()
    {
        playerMovement.FloatUp();
    }

    private void Won_Update()
    {

    }

    public void Alive_Enter()
    {
        state = PlayerState.ALIVE;
    }

    public void Dead_Enter()
    {
        state = PlayerState.DEAD;
        playerSprite.flipY = true;
        GetComponent<BoxCollider2D>().enabled = false;
        loseText.SetActive(true);
        StartCoroutine(GameManager.instance.DisplayObjectAfterDelay(replayPrompt));
    }

    public void Won_Enter()
    {
        state = PlayerState.WON;
        winText.SetActive(true);
        StartCoroutine(GameManager.instance.DisplayObjectAfterDelay(replayPrompt));
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoring.Score(collision);
    }

}
