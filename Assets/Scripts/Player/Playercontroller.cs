using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{

     float acceleration = 25;
    private float maxSpeed = 100;
    public float baseTurnSpeed = 100;
    // Base turn speed when moving at full speed

    public float deceleration = 5;
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
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, brakeStrength * Time.deltaTime);
            // Gradually reduce speed to zero based on brake strength
        }
    }
    //physics-based calculations work best in fixed update as we want a fixed interval to do calculations
    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        bool isBraking = Input.GetKey(KeyCode.Space);
        if (!isBraking)
        {
            if (moveInput != 0)
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed * moveInput, acceleration * Time.fixedDeltaTime);
                // Gradually increase speed towards max speed based on acceleration
            }
            else
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.fixedDeltaTime);
                // Decelerate to zero when no input is given
            }
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed / 3.6f);

        rb.velocity = transform.forward * currentSpeed;
        // Move the player forward based on current speed
    }
}
