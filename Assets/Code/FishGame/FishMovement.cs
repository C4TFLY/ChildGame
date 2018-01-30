using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class FishMovement : MonoBehaviour {

    private Rigidbody2D rb2d;
    [SerializeField] private float moveSpeed = 0.5f;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float upDown = Input.GetAxisRaw("Vertical");
        float rightLeft = Input.GetAxisRaw("Horizontal");

        Vector2 movementVector = new Vector2(rightLeft, upDown);
        movementVector.Normalize();

        rb2d.MovePosition(rb2d.position + (movementVector * moveSpeed));
    }

}
