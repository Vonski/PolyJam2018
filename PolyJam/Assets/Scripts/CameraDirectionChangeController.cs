using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirectionChangeController : MonoBehaviour {

    public cameraDirection myDirectionChange;
    GameObject myCamera;
    GameObject[] players;
    int counter;

	// Use this for initialization
	void Start () {
        myCamera = GameObject.FindGameObjectWithTag("MainCamera");
        players = GameObject.FindGameObjectsWithTag("Player");
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            counter++;
            if(counter == players.Length)
            {
                myCamera.GetComponent<CameraController>().transition = true;
                myCamera.GetComponent<CameraController>().direction = myDirectionChange;
                myCamera.GetComponent<CameraController>().lerpProgress = 0.0f;
                if (myDirectionChange == cameraDirection.LEFT || myDirectionChange == cameraDirection.RIGHT)
                {
                    myCamera.GetComponent<CameraController>().yConst = transform.position.y;
                    if (myDirectionChange == cameraDirection.LEFT)
                        myCamera.GetComponent<CameraController>().xStop = transform.position.x;
                    else
                        myCamera.GetComponent<CameraController>().xStop = transform.position.x;

                }
                if (myDirectionChange == cameraDirection.UP || myDirectionChange == cameraDirection.DOWN)
                {
                    myCamera.GetComponent<CameraController>().xConst = transform.position.x;
                    if (myDirectionChange == cameraDirection.UP)
                        myCamera.GetComponent<CameraController>().yStop = transform.position.y - 2.5f;
                    else
                        myCamera.GetComponent<CameraController>().yStop = transform.position.y + 2.5f;

                }
            }
        }
    }
}
