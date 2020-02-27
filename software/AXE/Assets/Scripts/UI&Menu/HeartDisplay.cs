using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDisplay : MonoBehaviour
{
    public GameObject Hrt;
    public bool isShown;
 
    // Start is called before the first frame update
    void Start()
    {
        isShown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShown)
        {
            Hrt.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            Hrt.GetComponent<Renderer>().enabled = true;
        }
    }
}
