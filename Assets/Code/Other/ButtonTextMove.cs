using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonTextMove : MonoBehaviour {

    private RectTransform textTransform;
    private SpriteState sprState = new SpriteState();

    private void Start()
    {
        textTransform = transform.GetChild(0).GetComponent<RectTransform>();
    }

    public void MoveText()
    {
        textTransform.asdasdasd
    }

}
