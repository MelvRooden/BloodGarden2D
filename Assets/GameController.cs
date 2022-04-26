using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int score = 0;

    public GameOverUI gameOverUI;

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
