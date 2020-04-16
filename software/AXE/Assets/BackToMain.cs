using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public TextMeshProUGUI option1;

    private int numberOfOptions = 4;

    private int selectedOption;

    void Start()
    {
        selectedOption = 1;
        option1.color = new Color32(255, 255, 255, 255);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            Back();
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
