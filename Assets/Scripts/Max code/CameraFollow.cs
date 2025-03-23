using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset =new Vector3 (0f, 0f, 0f);
    public float smoothSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //If we update the camera position in Update(),
    //it might move before the player updates their position for that frame.

    //Using LateUpdate(), we ensure the camera moves after the player moves,
    //making the camera movement smoother and preventing any jittering.
    private void LateUpdate()
    {
        if (target != null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);
        //The camera is smoothely moved to the desired position


    }
}
