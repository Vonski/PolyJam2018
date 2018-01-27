using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    float y_pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        y_pos = 10000.0f;
        GameObject [] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject p in players)
        {
            if (p.transform.position.y < y_pos)
                y_pos = p.transform.position.y;
        }
        transform.position = new Vector3(transform.position.x, y_pos, -10);

	}
}
