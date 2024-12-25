using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] group1; // Mga enemies para sa group 1 (e.g., Enemy 1 at 2)
    public GameObject[] group2; // Mga enemies para sa group 2 (e.g., Enemy 3 at 4)
    public GameObject[] group3; // Mga enemies para sa group 3 (e.g., Enemy 5 at 6)
    public float spawnRate = 2f;
    private float timer = 0f;
    public float zOffset = 0f; // Offset para sa Z-axis
    private int currentGroup = 0; // Index para malaman kung aling group ang i-spawn
    private int currentEnemyIndex = 0; // Index para malaman kung aling enemy sa group ang i-spawn

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Initial enemy spawn."); // Debug log to check if Start is called
        EnemySpawnCurrent(); // Initial na spawn
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            EnemySpawnCurrent(); // Normal na pag-spawn
            timer = 0;
        }
    }

    void EnemySpawnCurrent()
    {
        GameObject[] currentGroupArray = GetCurrentGroup();
        if (currentGroupArray != null && currentGroupArray.Length > 0)
        {
            // I-spawn ang current na enemy ayon sa index sa kasalukuyang group
            Debug.Log($"Spawning enemy from group {currentGroup + 1}, index {currentEnemyIndex}."); // Debug log
            Instantiate(currentGroupArray[currentEnemyIndex], transform.position + new Vector3(0, 0, zOffset), transform.rotation);
            currentEnemyIndex = (currentEnemyIndex + 1) % currentGroupArray.Length; // Increment at loop back sa simula kung maabot ang dulo
        }
        else
        {
            Debug.LogError("Current group array is null or empty.");
        }
    }

    GameObject[] GetCurrentGroup()
    {
        // Piliin ang tamang group batay sa currentGroup index
        switch (currentGroup)
        {
            case 0: return group1;
            case 1: return group2;
            case 2: return group3;
            default:
                Debug.LogError("Invalid current group index.");
                return null;
        }
    }

    // Para malaman kung nadadaan ang box collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("TriggerZone"))
        {
            Debug.Log("Player has entered the TriggerZone."); // Debug log to confirm trigger detection
            // Increment ang currentGroup upang pumili ng bagong group
            currentGroup = (currentGroup + 1) % 3; // Lumaktaw sa susunod na group at bumalik sa simula kung maabot ang dulo
            currentEnemyIndex = 0; // I-reset ang enemy index sa simula ng bagong group
        }
        else
        {
            Debug.Log($"Collider with tag '{other.tag}' entered, not Player or not TriggerZone.");
        }
    }
}
