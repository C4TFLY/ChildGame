using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb2d;
    [SerializeField] private float moveSpeed = 0.5f;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void MovePlayer()
    {
        float upDown = Input.GetAxisRaw("Vertical");
        float rightLeft = Input.GetAxisRaw("Horizontal");

        Vector2 movementVector = new Vector2(rightLeft, upDown);
        movementVector.Normalize();

        rb2d.AddForce(movementVector * moveSpeed * Time.deltaTime);
    }

    public void FloatUp()
    {
        rb2d.AddForce(new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime);
    }

}
