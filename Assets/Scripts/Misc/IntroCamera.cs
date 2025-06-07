using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCamera : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform pos1;
    public Transform pos2;
    bool MovingtoPos = true;
    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        if (MovingtoPos)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, pos2.transform.position, 1f * Time.deltaTime);
            if (Vector3.Distance(transform.position, pos2.position) < 0.1f)
            {
               MovingtoPos=false;
            }
        }

        else
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, pos1.transform.position, 1f * Time.deltaTime);
            if (Vector3.Distance(transform.position, pos1.position) < 0.1f)
            {
                MovingtoPos=true;
            }
        }
      

      
    }
}
