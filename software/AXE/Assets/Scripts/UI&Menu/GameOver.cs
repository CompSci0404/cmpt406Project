using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Image pointer;

    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;

    private int numberOfOptions = 2;

    private int selectedOption;

    void Start()
    {
        selectedOption = 1;
        option1.color = new Color32(255, 255, 255, 255);
        option2.color = new Color32(0, 0, 0, 255);

        pointer.transform.position = new Vector3(option1.transform.position.x + 2, option1.transform.position.y);
    }

    void Update()
    {
        float upDownMovement = Input.GetAxis("DPad Y");
        if (Input.GetKeyDown(KeyCode.DownArrow) || upDownMovement >= -1 && upDownMovement < 0)
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption > numberOfOptions)
            {
                selectedOption = numberOfOptions;
            }

            option1.color = new Color32(0, 0, 0, 255);
            option2.color = new Color32(0, 0, 0, 255);

            switch (selectedOption)
            {
                case 1:
                    option1.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option1.transform.position.x + 2, option1.transform.position.y, 0);
                    break;
                case 2:
                    option2.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option2.transform.position.x + 2, option2.transform.position.y, 0);
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

            switch (selectedOption)
            {
                case 1:
                    option1.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option1.transform.position.x + 2, option1.transform.position.y, 0);
                    break;
                case 2:
                    option2.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option2.transform.position.x + 2, option2.transform.position.y, 0);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            switch (selectedOption)
            {
                case 1:
                    RestartGame();
                    break;
                case 2:
                    QuitToMain();
                    break;
            }
        }
    }
    // Start Scene
    public void RestartGame()
    {
        int rand = Random.Range(1,3);
        SceneManager.LoadScene(rand);
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
