using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    float direction = 0;

    public float speed = 400;
    public float acceleration = 10f;
    public float deceleration = 10f;

    public Rigidbody2D playerRB;

    private float currentSpeed = 0;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Land.Move.canceled += ctx =>
        {
            direction = 0;
        };
    }

    void FixedUpdate()
    {
        // Check if game is over
        if (GameHeartScript.isGameOver)
        {
            // Allow the player to fall due to gravity by keeping only the vertical velocity
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
            return;  // Exit the FixedUpdate to prevent any horizontal movement
        }

        float targetSpeed = direction * speed * Time.deltaTime;

        // Smooth the speed
        if (direction != 0)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, deceleration * Time.deltaTime);
        }

        // Apply the velocity to the Rigidbody2D
        playerRB.velocity = new Vector2(currentSpeed, playerRB.velocity.y);
    }
}
