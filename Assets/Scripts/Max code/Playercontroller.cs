using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{

    public float acceleration = 1;
    private float maxSpeed = 140;
    public float baseTurnSpeed = 100;
    // Base turn speed when moving at full speed

    public float deceleration = 5f;
    public float minTurnSpeed = 20;
    // Minimum turning speed when moving slowly

    public Rigidbody rb;

    public float brakeStrength = 30;

    private float currentSpeed = 0;
    private Vector3 inputDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        // Prevents Rigidbody from rotating, allowing manual rotation control

    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        bool isBraking = Input.GetKey(KeyCode.Space);

        //Debug.Log("Move Input: " + moveInput + ", Turn Input: " + turnInput);

        
        float speedFactor = currentSpeed / (maxSpeed / 3.6f);
        // Calculate speed factor based on current speed relative to max speed

        
        float currentTurnSpeed = Mathf.Lerp(minTurnSpeed, baseTurnSpeed, speedFactor);
        // Adjust turn speed based on current movement speed (slower speeds = slower turns)

        // Only allow turning when the player is moving
        if (currentSpeed > 0.5f)
        {
            transform.Rotate(Vector3.up * turnInput * currentTurnSpeed * Time.deltaTime);
            // Rotate the player based on input, turn speed, and frame time



        }
        if (isBraking)
        {
            // Gradually reduce speed to zero based on brake strength
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, brakeStrength * Time.deltaTime);

        }
           

    }
    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        bool isBraking = Input.GetKey(KeyCode.Space);
        if (!isBraking)
        {
            if (moveInput != 0)
            {
                // Gradually increase speed towards max speed based on acceleration
                currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed * moveInput, acceleration * Time.fixedDeltaTime);

            }
            else
            {
                // Decelerate to zero when no input is given
                currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.fixedDeltaTime);

            }

        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed / 3.6f);


        // Move the player forward based on current speed
        rb.velocity = transform.forward * currentSpeed;
    }
}
