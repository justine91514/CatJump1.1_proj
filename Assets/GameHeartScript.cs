using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHeartScript : MonoBehaviour
{
    public GameObject Heartbar1, Heartbar2, Heartbar3, GameOver;
    public static int health;
    public static bool isGameOver = false;

    private bool heart1Lost = false;
    private bool heart2Lost = false;
    private bool heart3Lost = false;

    void Start()
    {
        health = 3;
        isGameOver = false;

        // Reset all hearts to active state
        heart1Lost = false;
        heart2Lost = false;
        heart3Lost = false;

        Heartbar1.gameObject.SetActive(true);
        Heartbar2.gameObject.SetActive(true);
        Heartbar3.gameObject.SetActive(true);
        GameOver.gameObject.SetActive(false);
    }

    void Update()
    {
        if (health > 3)
            health = 3;

        switch (health)
        {
            case 3:
                if (!heart1Lost) Heartbar1.gameObject.SetActive(true);
                if (!heart2Lost) Heartbar2.gameObject.SetActive(true);
                if (!heart3Lost) Heartbar3.gameObject.SetActive(true);
                GameOver.gameObject.SetActive(false);
                isGameOver = false;
                break;
            case 2:
                if (!heart1Lost) Heartbar1.gameObject.SetActive(true);
                if (!heart2Lost) Heartbar2.gameObject.SetActive(true);
                heart3Lost = true; // Heart 3 is permanently lost
                Heartbar3.gameObject.SetActive(false);
                GameOver.gameObject.SetActive(false);
                isGameOver = false;
                break;
            case 1:
                if (!heart1Lost) Heartbar1.gameObject.SetActive(true);
                heart2Lost = true; // Heart 2 is permanently lost
                Heartbar2.gameObject.SetActive(false);
                Heartbar3.gameObject.SetActive(false);
                GameOver.gameObject.SetActive(false);
                isGameOver = false;
                break;
            case 0:
                heart1Lost = true; // Heart 1 is permanently lost
                Heartbar1.gameObject.SetActive(false);
                Heartbar2.gameObject.SetActive(false);
                Heartbar3.gameObject.SetActive(false);
                GameOver.gameObject.SetActive(true);
                isGameOver = true;
                break;
        }
    }
}