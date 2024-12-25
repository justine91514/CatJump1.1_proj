using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollider : MonoBehaviour
{
    public LogicManager logic;
    private bool hasCollided = false; // Boolean flag para sa collision check

    void Awake()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check kung nasa tamang layer at hindi pa nag-collide
        if (collision.gameObject.layer == 3 && !hasCollided)
        {
            logic.addScore(1);
            hasCollided = true; // Set to true para hindi na mag-add ng score
        }
    }
}
