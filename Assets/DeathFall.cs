using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class DeathFall : MonoBehaviour
{
    public Transform player;       // Player na susundan
    public Vector3 offset = new Vector3(0, -10f, 0); // Offset ng Box Collider mula sa player
    private Vector3 lastPlayerPosition; // Para i-track ang nakaraang posisyon ng player
    public GameObject gameOverScreen;   // Game Over UI Panel

    void Start()
    {
        // I-save ang unang posisyon ng player
        lastPlayerPosition = player.position;
        // Siguraduhin na naka-disable ang Game Over Screen sa simula
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    void Update()
    {
        float verticalMovement = player.position.y - lastPlayerPosition.y;

        if (verticalMovement >= 0)
        {
            transform.position = player.position + offset;
        }
        else if (player.position.y < transform.position.y)
        {
            ActivateGameOver();
        }

        lastPlayerPosition = player.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // I-check kung ang player ang tumama sa Box Collider
        if (collision.CompareTag("Player"))
        {
            // Bawasan ang health sa GameHeartScript
            GameHeartScript.health = 0;

            // Ipakita ang Game Over Screen
            ActivateGameOver();
        }
    }

    void ActivateGameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // I-activate ang Game Over Screen
        }
        // I-pause ang laro
        Time.timeScale = 0f;
    }

    public void RetryGame()
    {
        // I-reset ang time scale at i-reload ang kasalukuyang scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
