using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource currentMusic;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMusic (AudioClip Music)
    {
        currentMusic.Stop();
        currentMusic.clip = Music;
        currentMusic.Play();
    }
}
