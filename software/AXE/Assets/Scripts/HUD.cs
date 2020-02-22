using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private Stack<GameObject> hearts;
    public GameObject heart;

    private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        for (int i = 0; i < stats.GetHearts(); i++)
            HeartOnHUD();
    }

    public void BuildHeartPrefabs()
    {
        hearts = new Stack<GameObject>();

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

    void HeartOnHUD()
    {
        //GameObject newHeart = Instantiate(hearts.Pop(), this.transform.position, Quaternion.identity);
    }

    private void Update()
    {

    }

    public void RemoveHUDHeart()
    {
        //hearts.Pop();
    }
}
