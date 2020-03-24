using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * This class contains all the methods needed to pause, resume, and quit the game. 
 */
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    public Image pointer;

    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;
    public TextMeshProUGUI option3;

    private int numberOfOptions = 3;

    private int selectedOption;

    void Start()
    {
        selectedOption = 1;
        option1.color = new Color32(255, 255, 255, 255);
        option2.color = new Color32(0, 0, 0, 255);
        option3.color = new Color32(0, 0, 0, 255);

        pointer.transform.position = new Vector3(option1.transform.position.x, option1.transform.position.y);
    }

    // Check for pause key
    private void Update()
    {
        float upDownMovement = Input.GetAxis("DPad Y");
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("StartButton"))
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
        if (Input.GetKeyDown(KeyCode.DownArrow) || upDownMovement >= -1 && upDownMovement < 0)
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption > numberOfOptions)
            {
                selectedOption = numberOfOptions;
            }

            option1.color = new Color32(0, 0, 0, 255);
            option2.color = new Color32(0, 0, 0, 255);
            option3.color = new Color32(0, 0, 0, 255);

            switch (selectedOption)
            {
                case 1:
                    option1.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option1.transform.position.x, option1.transform.position.y, 0);
                    break;
                case 2:
                    option2.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option2.transform.position.x, option2.transform.position.y, 0);
                    break;
                case 3:
                    option3.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option3.transform.position.x, option3.transform.position.y, 0);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || upDownMovement <= 1 && upDownMovement > 0)
        { //Input telling it to go up or down.
            selectedOption -= 1;
            if (selectedOption < 1)
            {
                selectedOption = 1;
            }

            option1.color = new Color32(0, 0, 0, 255);
            option2.color = new Color32(0, 0, 0, 255);
            option3.color = new Color32(0, 0, 0, 255);

            switch (selectedOption)
            {
                case 1:
                    option1.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option1.transform.position.x, option1.transform.position.y, 0);
                    break;
                case 2:
                    option2.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option2.transform.position.x, option2.transform.position.y, 0);
                    break;
                case 3:
                    option3.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option3.transform.position.x, option3.transform.position.y, 0);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            switch (selectedOption)
            {
                case 1:
                    Resume();
                    break;
                case 2:
                    /*Do option two*/
                    break;
                case 3:
                    QuitGame();
                    break;
            }
        }
    }

    // Resume time on the current scene
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        GameIsPaused = false;
    }

    // Pause the current scene
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        GameIsPaused = true;
    }

    // Quit when game is built
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        SceneManager.LoadScene(0);
    }
}
