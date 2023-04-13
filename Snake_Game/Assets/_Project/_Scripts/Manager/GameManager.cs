using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private FoodSpawn foodSpawn;
    [SerializeField] private SnakeController snakeController;

    public GameObject startPanel;
    public GameObject gameOverPanel;
    public bool gameStarted;

    private void Start()
    {
        gameStarted = false;
        startPanel.SetActive(true);
    }

    private void Update()
    {
        if (gameStarted) return;
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        gameStarted = true;
                
        startPanel.SetActive(false);
        foodSpawn.RandomSpawnPosition();

        snakeController.enabled = true;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }
}
