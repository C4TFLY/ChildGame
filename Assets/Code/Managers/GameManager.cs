using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static float camHeight;
    private static float camWidth;
    private Camera cam;

    public BoxCollider2D horizontalWall;
    public BoxCollider2D verticalWall;

    private void Start()
    {
        cam = Camera.main;
        camHeight = cam.orthographicSize * 2;
        camWidth = camHeight * cam.aspect;
    }

    private void FixedUpdate()
    {
        camHeight = cam.orthographicSize * 2;
        camWidth = camHeight * cam.aspect;
    }

}
