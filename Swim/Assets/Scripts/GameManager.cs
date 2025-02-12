using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Import TextMeshPro namespace

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton pattern for easy access

    public GameObject gameOverPanel; // Reference to the Game Over UI panel
    public TextMeshProUGUI scoreText; // TextMeshPro UI element for score display
    public Transform player; // Reference to the player's Transform
    private float startX; // Initial X position of the player
    private float score = 0f;
    public bool isGameOver = false;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (player != null)
        {
            startX = player.position.x; // Store the initial X position of the player
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            UpdateScore();
        }
    }

    // Update the player's score based on distance traveled
    void UpdateScore()
    {
        if (player != null)
        {
            score = player.position.x - startX; // Distance traveled
            if (scoreText != null)
            {
                scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString(); // Update TextMeshPro UI
            }
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            StartCoroutine(GameOverSequence());
        }
    }

    private System.Collections.IEnumerator GameOverSequence()
    {
        yield return StartCoroutine(ShakeCamera());
        ShowGameOverPanel();
    }

    private System.Collections.IEnumerator ShakeCamera()
    {
        Vector3 initialCameraPosition = Camera.main.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < 0.5f)
        {
            Vector3 randomOffset = Random.insideUnitCircle * 0.1f;
            Camera.main.transform.position = initialCameraPosition + randomOffset;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Camera.main.transform.position = initialCameraPosition;
    }

    private void ShowGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
