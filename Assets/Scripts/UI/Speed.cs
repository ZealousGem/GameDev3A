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
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("Player object not found! Make sure the Player is tagged correctly.");

        }

    }

    // used to show the speed
    void Update()
    {
        // Calculates the player's speed in km/h by getting the magnitude of the Rigidbody's velocity (in m/s),
        // then convert from meters per second to kilometers per hour by multiplying by 3.6
        float speed = playerRb.velocity.magnitude * 3.6f;
        speedText.text = "Speed: " + Mathf.RoundToInt(speed) + " km/h";

    }
}
