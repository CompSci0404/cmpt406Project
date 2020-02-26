using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudSwitch : MonoBehaviour
{
    public Animator animator;
    public bool ThorSwitch;
    public bool ValkSwitch;

    private GameObject[] ThorHealth;
    private GameObject[] ValkHealth;
    // Start is called before the first frame update
    void Start()
    {
        ThorSwitch = false;
        ValkSwitch = false;

        ThorHealth = GameObject.FindGameObjectsWithTag("ThorHrt");
        ValkHealth = GameObject.FindGameObjectsWithTag("ValkHrt");
    }

    // Update is called once per frame
    void Update()
    {
        //temporary if statements
        if (ThorSwitch)
        {

            //have to set other bool to false first or
            //animation will loop infinitly
            animator.SetTrigger("ValkSwitch");

            ThorSwitch = false;

            foreach (var Hrt in ThorHealth)
            {
                Hrt.GetComponent<Renderer>().sortingOrder = -1;
            }
            foreach (var Hrt in ValkHealth)
            {
                Hrt.GetComponent<Renderer>().sortingOrder = 1;
            }


        }
        if (ValkSwitch)
        {

            //have to set other bool to false first or
            //animation will loop infinitly
            animator.SetTrigger("ThorSwitch");

            ValkSwitch = false;

            foreach (var Hrt in ValkHealth)
            {
                Hrt.GetComponent<Renderer>().sortingOrder = -1;
            }
            foreach (var Hrt in ThorHealth)
            {
                Hrt.GetComponent<Renderer>().sortingOrder = 1;
            }
        }
    }
}
