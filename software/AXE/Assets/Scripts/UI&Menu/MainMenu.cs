using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/**
 * This class will contain the methods to start and stop the game as well as control for choosing items on the menu.
 */
public class MainMenu : MonoBehaviour
{

    [SerializeField]
    Canvas MenuCanavs;

    [SerializeField]
    Canvas ControllerMapping;

    public Image pointer;

    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;
    public TextMeshProUGUI option3;

    public Button playButton;
    public Button optionsButton;

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
            option3.color = new Color32(0, 0, 0, 255);

            switch (selectedOption) 
            {
                case 1:
                    option1.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option1.transform.position.x, option1.transform.position.y,0);
                    break;
                case 2:
                    option2.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option2.transform.position.x, option2.transform.position.y,0);
                    break;
                case 3:
                    option3.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option3.transform.position.x, option3.transform.position.y,0);
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
                pointer.transform.position = new Vector3(option1.transform.position.x, option1.transform.position.y,0);
                break;
            case 2:
                option2.color = new Color32(255, 255, 255, 255);
                pointer.transform.position = new Vector3(option2.transform.position.x, option2.transform.position.y,0);
                break;
            case 3:
                option3.color = new Color32(255, 255, 255, 255);
                pointer.transform.position = new Vector3(option3.transform.position.x, option3.transform.position.y,0);
                break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            switch (selectedOption) 
            {
                case 1:
                    ControllerCanvas();
                    break;
                case 2:
                    optionsButton.onClick.Invoke();
                    break;
                case 3:
                    QuitGame();
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("StartButton"))
        {
            StartGame();
        }
    }

    public void ControllerCanvas()
    {
        MenuCanavs.enabled = false;
        MenuCanavs.gameObject.SetActive(false);

        ControllerMapping.enabled = true;
        ControllerMapping.gameObject.SetActive(true);

    }

    // Start Scene
    public void StartGame()
    {
        int rand = Random.Range(1, 4);
        SceneManager.LoadScene(rand);
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
