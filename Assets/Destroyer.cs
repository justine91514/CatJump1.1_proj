using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAndPlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; // Prefab for the regular platform
    public GameObject springPlatformPrefab; // Prefab for the spring platform
    public GameObject player; // Reference to the player

    private bool isPlatformSpawning = false; // To prevent multiple platform spawns

    public float platformYOffset = 10f; // Height offset for platform spawning
    [Range(0f, 1f)] public float springPlatformSpawnChance = 0.2f; // Probability to spawn a spring platform (20%)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Triggered by: {collision.gameObject.name} with tag: {collision.gameObject.tag}");
        // Check if the trigger is for a Platform
        if (collision.gameObject.CompareTag("Platform") && !isPlatformSpawning)
        {
            Debug.Log("Platform Collider Entered!");
            StartCoroutine(SpawnPlatform(collision));
        }
    }

    private IEnumerator SpawnPlatform(Collider2D collision)
    {
        isPlatformSpawning = true;

        // I-delete ang lumang platform (spring o normal)
        bool wasSpringPlatform = collision.gameObject == springPlatformPrefab; // Check kung spring platform ang nadelete
        Destroy(collision.gameObject);

        float platX = Random.Range(-5.5f, 5.5f);
        float platY = player.transform.position.y + 15 + 3.61f;
        float platZ = -7.210001f;
        Vector3 spawnPositionPlatform = new Vector3(platX, platY, platZ);

        GameObject platformToSpawn;

        if (wasSpringPlatform)
        {
            // Kapag spring platform ang nadelete, siguraduhing normal platform ang ipapalit
            platformToSpawn = platformPrefab;
            Debug.Log("Spring Platform deleted. Spawning a Regular Platform to replace it.");
        }
        else
        {
            // Piliin kung spring o normal platform ang ipa-spawn
            platformToSpawn = Random.value < springPlatformSpawnChance ? springPlatformPrefab : platformPrefab;
            Debug.Log($"Spawning {(platformToSpawn == springPlatformPrefab ? "Spring" : "Regular")} Platform at: {spawnPositionPlatform}");
        }

        // Mag-spawn ng platform (normal or spring)
        Instantiate(platformToSpawn, spawnPositionPlatform, Quaternion.identity);

        isPlatformSpawning = false;

        yield break; // End the coroutine immediately
    }
}