using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    ALIVE,
    DEAD
}

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Scoring))]
[RequireComponent(typeof(PlayerSize))]
public class Player : MonoBehaviour {

    public static PlayerState state = PlayerState.ALIVE;

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

    public static void Alive_Enter()
    {
        state = PlayerState.ALIVE;
    }

    public static void Dead_Enter()
    {
        state = PlayerState.DEAD;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoring.Score(collision);
    }

}
