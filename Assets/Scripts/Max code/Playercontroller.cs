using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{

    public float acceleration = 1;
    public float maxSpeed = 20;
    public float baseTurnSpeed = 100;
    // Base turn speed when moving at full speed

    public float deceleration = 5f;
    public float minTurnSpeed = 20;
    // Minimum turning speed when moving slowly

    public Rigidbody rb;
    private Vector3 inputDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        //Debug.Log("Move Input: " + moveInput + ", Turn Input: " + turnInput);

        inputDirection = transform.forward * moveInput * acceleration;



        float speedFactor = rb.velocity.magnitude / maxSpeed;
        float currentTurnSpeed = Mathf.Lerp(minTurnSpeed, baseTurnSpeed, speedFactor);
        // Adjust turn speed based on current movement speed (slower speeds = slower turns)

        // Only allow turning when the player is moving
        if (rb.velocity.magnitude > 0.5f)
        {
            transform.Rotate(Vector3.up * turnInput * currentTurnSpeed * Time.deltaTime);

            
            

        }
           

    }
    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        if (moveInput != 0)
        {
            rb.velocity = transform.forward * moveInput * maxSpeed;
            // Apply velocity in the forward direction based on input and max speed
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, deceleration * Time.fixedDeltaTime);
            // If no input is given, gradually slow down the player
        }

        //rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
