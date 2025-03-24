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

    public float brakeStrength = 30;

    private float currentSpeed = 0;
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

        bool isBraking = Input.GetKey(KeyCode.Space);

        //Debug.Log("Move Input: " + moveInput + ", Turn Input: " + turnInput);

        //inputDirection = transform.forward * moveInput * acceleration;
        float speedFactor = currentSpeed / maxSpeed;


        //float speedFactor = rb.velocity.magnitude / maxSpeed;
        float currentTurnSpeed = Mathf.Lerp(minTurnSpeed, baseTurnSpeed, speedFactor);
        // Adjust turn speed based on current movement speed (slower speeds = slower turns)

        // Only allow turning when the player is moving
        if (currentSpeed > 0.5f)
        {
            transform.Rotate(Vector3.up * turnInput * currentTurnSpeed * Time.deltaTime);

            
            

        }
        if (isBraking)
        {
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
                currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed * moveInput, acceleration * Time.fixedDeltaTime);

            }
            else
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.fixedDeltaTime);

            }

        }
            

        //rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        rb.velocity = transform.forward * currentSpeed;
    }
}
