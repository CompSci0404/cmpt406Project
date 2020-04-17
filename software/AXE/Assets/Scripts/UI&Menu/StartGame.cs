using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    Canvas ControllerCanvas;

    [SerializeField]
    Canvas UIHelper;

    public Button playButton;

    bool pastController;

    private void Start()
    {
        pastController = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("StartButton"))
        {
            if (pastController)
            {
                StartScene();
            }
            else
            {
                UICanvas();
                pastController = true;
            }
        }
    }

    public void UICanvas()
    {
        //ControllerCanvas.enabled = false;
        //ControllerCanvas.gameObject.SetActive(false);
        UIHelper.sortingOrder = 1;
        playButton.gameObject.SetActive(false);
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
