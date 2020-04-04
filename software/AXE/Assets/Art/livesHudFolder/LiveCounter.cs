using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveCounter : MonoBehaviour
{
    private PlayerStats stats;
    public GameObject[] lives;
    public int NewlivesNum;
    // Start is called before the first frame update

    private bool addLife;

    public void UpdateLives(int NewTotal)
    {
        // life up to correctly update the life
        if (NewTotal > 1)
        {
            lives[NewTotal - 2].GetComponent<Renderer>().sortingOrder = -1;
        }
        

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
        addLife = false;
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
        if (addLife)
        {
            stats.SetLives(stats.GetLives() + 1);
            addLife = false;
        }
        UpdateLives(stats.GetLives()+1);
    }

    public void SetAddLife()
    {
        addLife = true;
    }
}
