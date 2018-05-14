using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyFish : MonoBehaviour {

    public Fish properties;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trashcan"))
        {
            Destroy(gameObject);
        }
    }

}
