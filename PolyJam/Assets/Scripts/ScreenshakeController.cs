using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshakeController : MonoBehaviour {

    public bool isShaking = false;
    public float duration;
    public float startTime;
    public float strength;
    GameObject myCamera;

	// Use this for initialization
	void Start () {
        myCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	public void AddScreenShake() {
        if(isShaking)
        {
            if (startTime + duration < Time.time)
                isShaking = false;
            myCamera.transform.position += Random.insideUnitSphere * strength;
        }
    }
}
