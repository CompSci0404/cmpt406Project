using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This class will contain the methods to start and stop the game. 
 */
public class MainMenu : MonoBehaviour
{
    // Start Scene
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
    }
    
    // Quit when game is built
    public void QuitGame()
    {
        Debug.Log("Quitting the game.");
        Application.Quit();
    }
}
