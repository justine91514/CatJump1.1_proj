using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemy_chaser : MonoBehaviour
{
    public GameObject player;
    public float speed = 1f;         // Vertical speed for moving down
    public float chaseSpeed = 0.5f;  // Horizontal speed when chasing the player
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player"); // Assuming your player has the tag "Player"
        }
        // Set the z-coordinate of the enemy to -48.73358 when it spawns
        transform.position = new Vector3(transform.position.x, transform.position.y, -48.73358f);
    }
    // Update is called once per frame
    void Update()
    {
        // Get the direction towards the player
        Vector2 direction = player.transform.position - transform.position;
        // Move horizontally towards the player at a slower chase speed
        if (player.transform.position.x != transform.position.x)
        {
            float step = chaseSpeed * Time.deltaTime;
            transform.position = new Vector2(
                Mathf.MoveTowards(transform.position.x, player.transform.position.x, step),
                transform.position.y
            );
        }
        // Move vertically down at the regular speed
        transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        // Destroy the enemy if it goes below the screen limit
        if (transform.position.y <= -8.98f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Use a switch statement for better readability
        switch (collision.gameObject.tag)
        {
            case "Destroyer":
                // Ignore collisions with the "Destroyer" object
                return;
            case "Player":
                // Handle collisions with the "Player" object
                GameHeartScript.health -= 1;
                break;
            // You can add other cases if needed
            default:
                // Handle other cases if necessary
                break;
        }
    }

}
