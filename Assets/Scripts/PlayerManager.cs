using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public static int coins;
    public GameObject gameOverPanel;
    public GameObject pauseMenuPanel;
    public GameObject gameFinishPanel;
    public TextMeshProUGUI coinText;


    private void Awake()
    {
        isGameOver = false;
        coins = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coins.ToString();

        if (isGameOver)
        {
            gameOverPanel.SetActive(true);
            
        }
        
    }

    public void FinishGame()
    {
        StartCoroutine(GameFinish());
        gameFinishPanel.SetActive(true);
    }

    IEnumerator GameFinish()
    {
        yield return new WaitForSeconds(2);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        SceneManager.LoadScene("StartMenu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
    }

    
}
