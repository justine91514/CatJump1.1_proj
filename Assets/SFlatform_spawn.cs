using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFlatform_spawn : MonoBehaviour
{
    public GameObject SFlatform;      // The object to spawn
    public float spawnRate = 2f;      // Time interval between spawns
    private float timer = 0f;         // Timer to track spawn intervals

    public float leftLimit = -1.8f;
    public float rightLimit = 1.79f;

    public float deadZone = -8.98f;
    public float moveSpeed = 2f;      // Speed at which platforms move down

    void Start()
    {
        SpawnFlatform();
    }

    void Update()
    {
        // Timer to control spawn intervals
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;  // Increment timer by deltaTime
        }
        else
        {
            SpawnFlatform();          // Spawn new platform
            timer = 0f;               // Reset timer
        }
    }

    void SpawnFlatform()
    {
        // Randomize the X position between leftLimit and rightLimit
        float spawnX = Random.Range(leftLimit, rightLimit);

        // Instantiate the platform at the randomized X position
        GameObject platform = Instantiate(SFlatform, new Vector3(spawnX, transform.position.y, 4.14f), Quaternion.identity);

        // Assign movement to the spawned platform
        platform.AddComponent<PlatformMovement>().moveSpeed = moveSpeed;
    }
}

public class PlatformMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private float deadZone = -8.98f;  // The Y position at which the platform gets destroyed

    void Update()
    {
        // Move the platform downward
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        // Destroy the platform once it reaches the deadZone
        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 600f);

        }
    }
}
