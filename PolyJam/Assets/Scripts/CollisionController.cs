using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hehe");
        if (collision.gameObject.tag == "Player")
            Debug.Log("player");
        else if (collision.gameObject.tag == "Obstacle")
            Debug.Log("Obstacle");
        

    }
}
