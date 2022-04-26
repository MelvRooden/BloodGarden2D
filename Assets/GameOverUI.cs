using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private Text scoreTxt;
    [SerializeField]
    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);

        scoreTxt.text = "Score: " + score.ToString();
    }

    public void RestartBtn()
    {
        gameController.LoadNewScene("SceneOne");
    }
}
