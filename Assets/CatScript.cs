using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    public LogicManager logic;
    private AudioManager audioManager;
    private bool hasPlayedSound = false; // Flag to track if the sound has been played

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RightWall")
        {
            transform.position = new Vector3(-1.97f, transform.position.y, transform.position.z);
        }
        else if (other.gameObject.tag == "LeftWall")
        {
            transform.position = new Vector3(2.016f, transform.position.y, transform.position.z);
        }
        else if (other.gameObject.tag == "Platform" && !hasPlayedSound)
        {
            // Check if the Cat is landing on top of the platform
            Vector2 contactPoint = other.ClosestPoint(transform.position);
            if (contactPoint.y > other.bounds.center.y) // Only trigger if on top of the platform
            {
                audioManager.PlaySFX(audioManager.Hop);
                hasPlayedSound = true; // Set the flag to true
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            hasPlayedSound = false; // Reset the flag when exiting the platform
        }
    }
}
