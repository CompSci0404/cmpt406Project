using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveCounter : MonoBehaviour
{
    private PlayerStats stats;
    public GameObject[] lives;
    public int NewlivesNum;
    // Start is called before the first frame update

    public void UpdateLives(int NewTotal)
    {
        if(NewTotal > lives.Length)
        {
            //throw error
        }
        else if(NewTotal == 0)
        {
            stats.Death();
        }
        else if (lives.Length == NewTotal)
        {
            lives[NewTotal - 1].GetComponent<Renderer>().sortingOrder = 1;
        }
        else
        {
            lives[NewTotal].GetComponent<Renderer>().sortingOrder = -1;
            lives[NewTotal - 1].GetComponent<Renderer>().sortingOrder = 1;
        }
    }
    void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        foreach (var life in lives)
        {
            life.GetComponent<Renderer>().sortingOrder = -1;
        }
        NewlivesNum = stats.GetLives();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLives(stats.GetLives()+1);
    }
}
