using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {
    AudioClip clip;
    public bool changed_clip=false;
    bool collisionDoneOnce = false;
	// Use this for initialization
	void Start () {
        clip = this.GetComponent<AudioSource>().clip;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collisionDoneOnce)
            {
                collisionDoneOnce = false;
                collision.gameObject.GetComponent<CollisionController>().collisionDoneOnce = false;
            }
            else
            {
                collisionDoneOnce = true;
                collision.gameObject.GetComponent<CollisionController>().collisionDoneOnce = true;
                return;
            }
            AudioClip tmp = this.GetComponent<AudioSource>().clip;
            this.GetComponent<AudioSource>().clip = collision.gameObject.GetComponent<AudioSource>().clip;
            collision.gameObject.GetComponent<AudioSource>().clip = tmp;
            if (this.GetComponent<AudioSource>().clip != clip)
                changed_clip = true;
            else
                changed_clip = false;

        }
        else if (collision.gameObject.tag == "Obstacle")
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenshakeController>().isShaking = true;
        else
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenshakeController>().isShaking = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenshakeController>().startTime = Time.time;
        }
            


    }
}
