using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that when attached to an object will stop it from being deleted between scenes
/// </summary>
public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance
    {
        get;
        set;
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}