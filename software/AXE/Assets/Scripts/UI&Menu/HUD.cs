using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class will control the games HUD to show the player their current hearts, lives,
 * inventory, and character icon. 
 */
public class HUD : MonoBehaviour
{
    private PlayerStats stats;
    private Stack<GameObject> hearts;
    private GameObject heartSpaces;

    public Animator animator;

    public bool ThorSwitch;
    public bool ValkSwitch;

    public GameObject[] ThorHealth;
    public GameObject[] ValkHealth;

    // Start is called before the first frame update.
    void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        hearts = new Stack<GameObject>();

        ThorSwitch = false;
        ValkSwitch = false;

        ThorHealth = GameObject.FindGameObjectsWithTag("ThorHrt");
        ValkHealth = GameObject.FindGameObjectsWithTag("ValkHrt");
    }

    // Create our heart prefab to be used by our hud.
    public void BuildHeartPrefabs()
    {
        object[] prefabs;
        int counter = 0;

        prefabs = Resources.LoadAll("Heart", typeof(GameObject));

        while (counter < prefabs.Length)
        {
            GameObject newItem = (GameObject)prefabs[counter];

            hearts.Push(newItem);

            counter++;
        }
    }

    // Add a heart to the hud at a given offset or in a given space.
    void HeartOnHUD(GameObject heartSpaces)
    {
        GameObject newHeart = Instantiate(hearts.Pop(), heartSpaces.transform.position, Quaternion.identity);
        Debug.Log(hearts.ToString());
    }

    // Remove a heart from the HUD when damage is taken.
    public void RemoveHUDHeart()
    {
        //hearts.Pop();
    }

    // Method will play an animation to switch the character icons in the HUD. 
    public void ChangeCharacterIcon()
    {
        //temporary if statements
        if (ThorSwitch)
        {
            //have to set other bool to false first or
            //animation will loop infinitly
            animator.SetTrigger("ValkSwitch");

            foreach (var Hrt in ThorHealth)
            {
                Hrt.GetComponent<Renderer>().sortingOrder = -1;
            }
            foreach (var Hrt in ValkHealth)
            {
                Hrt.GetComponent<Renderer>().sortingOrder = 1;
            }
            ThorSwitch = false;
        }
        if (ValkSwitch)
        {
            //have to set other bool to false first or
            //animation will loop infinitly
            animator.SetTrigger("ThorSwitch");

            foreach (var Hrt in ValkHealth)
            {
                Hrt.GetComponent<Renderer>().sortingOrder = -1;
            }
            foreach (var Hrt in ThorHealth)
            {
                Hrt.GetComponent<Renderer>().sortingOrder = 1;
            }
            ValkSwitch = false;
        }
    }
}
