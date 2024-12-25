using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSpawn : MonoBehaviour
{
    public Transform player;   // Player na susundan
    private float initialY;    // Ang orihinal na Y position ng BG
    private const float fixedZ = 4.6f; // Fixed Z-coordinate ng background

    void Start()
    {
        // Kunin ang orihinal na Y position ng background
        initialY = transform.position.y;
    }

    void Update()
    {
        // Panatilihin ang Y at Z position pero sundan ang X position ng player
        transform.position = new Vector3(player.position.x, initialY, fixedZ);
    }
}
