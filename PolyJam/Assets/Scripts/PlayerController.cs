using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector2 actualDirection;
    public Vector2 targetDirection;
    public float actualAngle;
    public float targetAngle;
    public float maxSpeed;
    public float speedDelta;
    public float passiveSpeedLoss;
    public float angleDiffModifier;
    public float rotationSpeedModifier;
    public float directionRotationSpeedModifier;
    public float test;
    public int id;
    float rotationSpeed;
    float directionRotationSpeed;
    float angleDiff;
    float speed;
    
    // Use this for initialization
	void Start () {
        actualDirection = targetDirection = Vector2.up;
        actualAngle = targetAngle = 0;
        speed = 0;
        rotationSpeed = maxSpeed * rotationSpeedModifier;
        directionRotationSpeed = maxSpeed * directionRotationSpeedModifier;
        angleDiff = maxSpeed * angleDiffModifier;
	}


    // Update is called once per frame
    void Update () {
        if (Input.GetAxis("P" + id + "_Horizontal")!=0)
        {
            if (Input.GetAxis("P" + id + "_Horizontal") > 0)
            {
                targetAngle = actualAngle - angleDiff;
            }    
            
            if (Input.GetAxis("P" + id + "_Horizontal") < 0)
            {
                targetAngle = actualAngle + angleDiff;
            }

            targetDirection = Quaternion.Euler(0, 0, targetAngle) * Vector2.up;
        }
        if (Input.GetButton("P" + id + "_Acceleration"))
        {
            if (maxSpeed > speed)
                speed += Mathf.Pow(maxSpeed - speedDelta, 2)/100;
            else
                speed = maxSpeed;
        }
        else if (!Input.GetButton("P" + id + "_Deceleration"))
        {
            if (speed > 0)
                speed -= speedDelta * passiveSpeedLoss;
            else
                speed = 0;
        }
        if (Input.GetButton("P" + id + "_Deceleration"))
        {
            if (speed > 0)
                speed -= Mathf.Pow(maxSpeed - speedDelta, 2)/100;
            else
                speed = 0;
        }

        actualAngle = Mathf.Lerp(actualAngle, targetAngle, rotationSpeed);
        actualDirection = Vector2.Lerp(actualDirection, targetDirection, directionRotationSpeed).normalized;
        GetComponent<Rigidbody2D>().rotation = actualAngle;
        GetComponent<Rigidbody2D>().velocity = actualDirection * speed;
    }
}
