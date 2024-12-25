using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpaceDestroyer : MonoBehaviour
{
    
    public GameObject player; // Reference to the player
    public GameObject BGPrefab; // Prefab for the background

    private bool isBGSpawning = false; // To prevent multiple BG spawns

    public float BGYOffset = 10f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Triggered by: {collision.gameObject.name} with tag: {collision.gameObject.tag}");
        //Code For BG
        // Check if the trigger is for a Background (BG)
        if (collision.gameObject.CompareTag("BG") && !isBGSpawning)
        {
            Debug.Log("BG Collider Entered!");
            StartCoroutine(SpawnBG(collision));
        }
    }

    //Code For BG
    private IEnumerator SpawnBG(Collider2D collision)
    {
        isBGSpawning = true;

        Destroy(collision.gameObject);

        Vector3 spawnPositionBG = new Vector3(
            player.transform.position.x,
            player.transform.position.y + BGYOffset
            
        );

        Debug.Log($"Spawning new Background at: {spawnPositionBG}");

        Instantiate(BGPrefab, spawnPositionBG, Quaternion.identity);

        // Optional delay
        yield return

        isBGSpawning = false;
    }
}
