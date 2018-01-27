using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector2 actualDirection;
    public Vector2 targetDirection;
    public float actualAngle;
    public float targetAngle;
    public float speed;
    public float test;
    
    // Use this for initialization
	void Start () {
        actualDirection = targetDirection = Vector2.up;
        actualAngle = targetAngle = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                targetDirection = Quaternion.Euler(0, 0, -45.0f) * actualDirection.normalized;
                targetAngle = actualAngle - 45.0f;
            }    
            
            if (Input.GetAxis("Horizontal") < 0)
            {
                targetDirection = Quaternion.Euler(0, 0, 45.0f) * actualDirection.normalized;
                targetAngle = actualAngle + 45.0f;
            }
        }

        actualAngle = Mathf.Lerp(actualAngle, targetAngle, 0.03f);
        actualDirection = Vector2.Lerp(actualDirection, targetDirection, 0.03f).normalized;
        GetComponent<Rigidbody2D>().velocity = actualDirection * speed;
    }
}
