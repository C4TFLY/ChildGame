using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class test : MonoBehaviour {

    public string asd;

	// Use this for initialization
	void Start () {
        GetComponent<TextMeshProUGUI>().text = asd;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
