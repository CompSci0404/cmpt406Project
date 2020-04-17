using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField]
    Canvas MenuCanavs;

    [SerializeField]
    Canvas ControllerMapping;

    public Image pointer;

    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;
    public TextMeshProUGUI option3;
    public TextMeshProUGUI option4;

    public Button playButton;
    public Slider volumeSlider;
    public Button controllerButton;
    public Button backButton;
    private int numberOfOptions = 4;

    private int selectedOption;
    public GameObject pauseMenu;

    public GameObject pcControlsUI;
    public GameObject controllersUI;

    private float upDownMovement = 0;
    private float lastUpDownMovement = 0;

    void Start()
    {
        selectedOption = 1;
        option1.color = new Color32(255, 255, 255, 255);
        option2.color = new Color32(0, 0, 0, 255);
        option3.color = new Color32(0, 0, 0, 255);
        option4.color = new Color32(0, 0, 0, 255);

        pointer.transform.position = new Vector3(option1.transform.position.x, option1.transform.position.y);
    }

    void Update()
    {
        lastUpDownMovement = upDownMovement;
        upDownMovement = Input.GetAxisRaw("DPad Y");
        if (Input.GetKeyDown(KeyCode.DownArrow) || (upDownMovement == -1 && lastUpDownMovement != -1))
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption > numberOfOptions)
            {
                selectedOption = numberOfOptions;
            }

            option1.color = new Color32(0, 0, 0, 255);
            option2.color = new Color32(0, 0, 0, 255);
            option3.color = new Color32(0, 0, 0, 255);
            option4.color = new Color32(0, 0, 0, 255);

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
                case 4:
                    option4.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option4.transform.position.x, option4.transform.position.y, 0);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || (upDownMovement == 1 && lastUpDownMovement != 1))
        { //Input telling it to go up or down.
            selectedOption -= 1;
            if (selectedOption < 1)
            {
                selectedOption = 1;
            }

            option1.color = new Color32(0, 0, 0, 255);
            option2.color = new Color32(0, 0, 0, 255);
            option3.color = new Color32(0, 0, 0, 255);
            option4.color = new Color32(0, 0, 0, 255);

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
                case 4:
                    option4.color = new Color32(255, 255, 255, 255);
                    pointer.transform.position = new Vector3(option4.transform.position.x, option4.transform.position.y, 0);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 1"))
        {
            switch (selectedOption)
            {
                case 1:
                    // change volume
                    if (Input.GetKeyDown("joystick button 0"))
                    {
                        VolumeUp();
                    }
                    else if (Input.GetKeyDown("joystick button 1"))
                    {
                        VolumeDown();
                    }
                    break;
                case 2:
                    // change controls
                    if (Input.GetKeyDown("joystick button 0"))
                    {
                        controllerButton.onClick.Invoke();
                    }
                    break;
                case 3:
                    // Show controls
                    if (Input.GetKeyDown("joystick button 0"))
                    {
                        ShowControlUI();
                    }
                    break;
                case 4:
                    // go back
                    if (Input.GetKeyDown("joystick button 0"))
                    {
                        Back();
                    }
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("StartButton"))
        {
            Back();
        }
    }

    public void VolumeUp()
    {
        volumeSlider.value += .1f;
    }
    public void VolumeDown()
    {
        volumeSlider.value -= .1f;
    }
    public void Back()
    {
        if (pauseMenu.GetComponent<PauseMenu>() != null)
        {
            pauseMenu.GetComponent<PauseMenu>().SetInputCD();
        }
        backButton.onClick.Invoke();
    }

    public void CloseControlUI()
    {
        ScriptableControls myControls = (ScriptableControls)Resources.Load("MyControls");
        if (myControls.PC)
        {
            pcControlsUI.SetActive(false);
            this.gameObject.SetActive(true);
        }
        else
        {
            controllersUI.SetActive(false);
            this.gameObject.SetActive(true);
        }
    }

    public void ShowControlUI()
    {
        ScriptableControls myControls = (ScriptableControls)Resources.Load("MyControls");
        if (myControls.PC)
        {
            pcControlsUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            controllersUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}

