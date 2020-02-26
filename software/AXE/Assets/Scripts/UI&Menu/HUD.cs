using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class will control the games HUD to show the player their current hearts, lives,
 * inventory, and character icon. 
 */
public class HUD : MonoBehaviour
{
    private HudSwitch switcher;
    private PlayerStats stats;
    private Stack<GameObject> hearts;
    private GameObject heartSpaces;

    // Start is called before the first frame update.
    void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        hearts = new Stack<GameObject>();
        heartSpaces = FindObjectOfType<GameObject>();
        for (int i = 0; i < stats.GetCurrHearts(); i++)
        {
            BuildHeartPrefabs();
            HeartOnHUD(i);
        }
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
    void HeartOnHUD(int index)
    {
        GameObject newHeart = Instantiate(hearts.Pop(), heartSpaces.transform.position, Quaternion.identity);
    }

    private void Update()
    {

    }

    // Remove a heart from the HUD when damage is taken.
    public void RemoveHUDHeart()
    {
        //hearts.Pop();
    }

    // Method will play an animation to switch the character icons in the HUD. 
    public void ChangeCharacterIcon()
    {
        // Change sprite from 0- 20 to go through the swap.
    }
}
