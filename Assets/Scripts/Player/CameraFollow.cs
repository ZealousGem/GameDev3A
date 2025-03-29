using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CameraFollow : MonoBehaviour
{

    public Transform target; //This is for the transform(position) of the target which is the player
    public Vector3 offset =new Vector3 (0f, 0f, 0f); 
    public float smoothSpeed = 5;
    // Start is called before the first frame update
    

    //Using LateUpdate(), we ensure the camera moves after the player moves,
    //making the camera movement smoother and preventing any jittering.
    private void LateUpdate()
    {
        if (target != null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        // Smoothly interpolates the camera's current position towards the desired position based on the smoothSpeed value and frame time
        transform.LookAt(target);
        

    }
}
