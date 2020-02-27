using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start Scene
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
    }

    // Quit when game is built
    public void QuitToMain()
    {
        Debug.Log("Returning to main");
        SceneManager.LoadScene(0);
    }
}
