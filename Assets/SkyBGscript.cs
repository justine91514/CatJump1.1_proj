using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBGscript : MonoBehaviour
{
    //public float moveSpeed = 1; // Bilis ng galaw ng BG
    public Transform player;   // Player na susundan
    private float initialY;    // Ang orihinal na Y position ng BG

    void Start()
    {
        // Kunin ang orihinal na Y position ng background
        initialY = transform.position.y;
    }

    void Update()
    {
        // Panatilihin ang Y position pero sundan ang X position ng player
        transform.position = new Vector3(player.position.x, initialY, transform.position.z);
    }
}
