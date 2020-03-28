using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("StartButton"))
        {
            StartScene();
        }
    }

    // Start Scene
    public void StartScene()
    {
        int rand = Random.Range(1, 4);
        SceneManager.LoadScene(rand);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
    }
}
