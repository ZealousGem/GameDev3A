using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public Rigidbody playerRb;
    public TextMeshProUGUI speedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = playerRb.velocity.magnitude * 3.6f;
        speedText.text = "Speed: " + Mathf.RoundToInt(speed) + " km/h";

    }
}
