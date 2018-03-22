﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyFish : MonoBehaviour {

    public Fish properties;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = properties.image;
        //GetComponent<BoxCollider2D>().size = properties.colliderSize;
        gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trashcan"))
        {
            Destroy(gameObject);
        }
    }

}
