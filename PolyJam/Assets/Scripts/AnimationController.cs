using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {
    public List<Sprite> sprites;
    int list_iter = 0;
    public float delta_time=1;
    float last_time;

	// Use this for initialization
	void Start () {
        last_time = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
        float current_time = Time.time;
        if (current_time - last_time >= delta_time)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[list_iter];
                list_iter++;
                if (list_iter == sprites.Count)
                    list_iter = 0; 
            last_time = current_time;
        }

	}
}
