using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{

    public float acceleration = 1;
    public float maxSpeed = 20;
    public float turnSpeed = 100;
    public float deceleration = 5f;

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
        transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);

    }
    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        if (moveInput != 0)
        {
            rb.velocity = transform.forward * moveInput * maxSpeed;
            //Debug.Log("Applying Force: " + inputDirection);
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, deceleration * Time.fixedDeltaTime);
        }

        //rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
