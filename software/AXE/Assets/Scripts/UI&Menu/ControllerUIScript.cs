using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUIScript : MonoBehaviour
{
    public GameObject OptionsUI;

    private void Update()
    {
        if (Input.GetButtonDown("StartButton") || Input.GetKeyDown(KeyCode.Escape)) 
        {
            OptionsUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
