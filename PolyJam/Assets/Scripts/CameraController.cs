using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum cameraDirection { UP, RIGHT, DOWN, LEFT };

public class CameraController : MonoBehaviour {

    public cameraDirection direction;
    public bool transition;
    public float lerpProgress;
    public float xConst, yConst;
    float yPos, xPos;
    public float xStop, yStop;

	// Use this for initialization
	void Start () {
        yStop = 1000.0f;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players)
        {
            if (p.transform.position.y < yPos)
                yPos = p.transform.position.y;
        }
        yStop = yPos;
        xStop = 0.0f;
        transition = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(direction == cameraDirection.UP)
        {
            yPos = 10000.0f;
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject p in players)
            {
                if (p.transform.position.y < yPos)
                    yPos = p.transform.position.y;
            }
            yPos += 2.5f;
            if (yStop < yPos)
                yStop = yPos;
            yPos = yStop;
            xPos = xConst;
        }
        if (direction == cameraDirection.RIGHT)
        {
            xPos = 10000.0f;
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject p in players)
            {
                if (p.transform.position.x < xPos)
                    xPos = p.transform.position.x;
            }
            xPos += 3.5f;
            if (xStop < xPos)
                xStop = xPos;
            xPos = xStop;
            yPos = yConst;
        }
        if (direction == cameraDirection.DOWN)
        {
            yPos = -10000.0f;
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject p in players)
            {
                if (p.transform.position.y > yPos)
                    yPos = p.transform.position.y;
            }
            yPos -= 2.5f;
            if (yStop > yPos)
                yStop = yPos;
            yPos = yStop;
            xPos = xConst;
        }
        if (direction == cameraDirection.LEFT)
        {
            xPos = -10000.0f;
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject p in players)
            {
                if (p.transform.position.x > xPos)
                    xPos = p.transform.position.x;
            }
            xPos -= 3.5f;
            if (xStop > xPos)
                xStop = xPos;
            xPos = xStop;
            yPos = yConst;
        }


        if (transition)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(xPos,yPos,-10), lerpProgress);
            lerpProgress += 0.002f;
            if (lerpProgress >= 1.0f)
                transition = false;
        }
        else
        {
            transform.position = new Vector3(xPos, yPos, -10);
        }

	}
}
