using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartMenu()
    {
        // Load the game scene
        SceneManager.LoadScene("Main");
    }

    public void MainScreen()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void HelpMenu()
    {
        SceneManager.LoadScene("HelpMenu");
    }
}
