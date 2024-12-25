using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startingSceneTransition;
    [SerializeField] private GameObject _endingSceneTransition;
    [SerializeField] private float _transitionDuration = 1.0f; // Tagal ng transition effect.

    public void PlayGame()
    {
        // Simulan ang transition.
        _startingSceneTransition.SetActive(true);
        StartCoroutine(LoadGameSceneAfterTransition());
    }

    private IEnumerator LoadGameSceneAfterTransition()
    {
        // Hintayin ang tagal ng transition bago mag-load ng bagong scene.
        yield return new WaitForSeconds(_transitionDuration);
        _endingSceneTransition.SetActive(true);
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
