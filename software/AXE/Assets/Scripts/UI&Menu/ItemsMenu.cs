using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * This class contains all the methods needed to pause and resume the game while looking at the items 
 */
public class ItemsMenu : MonoBehaviour
{
    public GameObject ItemMenuUI;

    private static bool GameIsPaused = false;

    // Check for select key
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tilde) || Input.GetButtonDown("SelectButton"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resume time on the current scene
    public void Resume()
    {
        ItemMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        GameIsPaused = false;
    }

    // Pause the current scene
    void Pause()
    {
        ItemMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        GameIsPaused = true;
    }
}
