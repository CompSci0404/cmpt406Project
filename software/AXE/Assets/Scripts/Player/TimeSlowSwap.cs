using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlowSwap : MonoBehaviour
{
    public float duration = 1f;
    [SerializeField]
    GameObject screenDimmer;

    public void SlowForSwap()
    {
        Debug.Log("IN SLOW SWAP");
        screenDimmer.SetActive(true);
        Time.timeScale = .5f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        Invoke("Disable", duration);
    }

    private void Disable()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        screenDimmer.SetActive(false);
    }

}
