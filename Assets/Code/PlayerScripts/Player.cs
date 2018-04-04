using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            default:
                Debug.LogError("Something went wrong regarding Player states.");
                break;
        }
    }

    private void Alive_Update()
    {
        playerMovement.MovePlayer();
    }

    private void Dead_Update()
    {

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
        playerSprite.sprite = null;
    }

    public void Won_Enter()
    {
        state = PlayerState.WON;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoring.Score(collision);
    }

}
