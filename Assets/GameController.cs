using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int score = 0;

    [SerializeField]
    private GameOverUI gameOverUI;

    public void GameOver()
    {
        gameOverUI.Setup(score);
    }

    public void AddToScore(int points)
    {
        score += points;
    }

    public void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
