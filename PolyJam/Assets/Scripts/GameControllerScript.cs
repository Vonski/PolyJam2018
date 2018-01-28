using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    GameObject[] players;
    float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > startTime + 8.0)
        {
            for (int i = 0; i < players.Length; ++i)
                players[i].GetComponent<PlayerController>().enabled = true;
        }
        else
        {
            for (int i = 0; i < players.Length; ++i)
                if (Time.time > 1.0f + startTime + (players[i].GetComponent<PlayerController>().id - 1) * 1.5f && Time.time < 1.0f + startTime + players[i].GetComponent<PlayerController>().id * 1.5f)
                {
                    players[i].GetComponent<AudioSource>().Play();
                }
            for (int i = 0; i < players.Length; ++i)
                if (Time.time > 1.0f + startTime + (players[i].GetComponent<PlayerController>().id) * 1.5f)
                {
                    players[i].GetComponent<AnimationController>().enabled = true;
                }
        }
            
	}
}
