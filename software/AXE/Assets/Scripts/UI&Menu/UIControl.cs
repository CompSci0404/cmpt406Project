using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIControl : MonoBehaviour
{
    private ScriptableControls myControls;
    public void Start()
    {
        myControls = (ScriptableControls)Resources.Load("MyControls");

    }

    public void Update()
    {
        if (myControls.PC)
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = "PC";
        }
        else if (myControls.Controller)
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = "Controller";
        }
        else
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = "PC";
        }
    }

    public void ChangeControls()
    {
        if (myControls.PC)
        {
            myControls.PC = false;
            myControls.Controller = true;
        }
        else
        {
            myControls.PC = true;
            myControls.Controller = false;
        }
    }
}
