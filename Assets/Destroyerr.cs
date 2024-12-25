using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object has a "Platform" tag
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log($"Destroying platform: {collision.gameObject.name}");
            Destroy(collision.gameObject);
        }
    }
}
