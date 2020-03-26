using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{

    public AudioClip newTrack;

    private MusicManager MManager ;

    // Start is called before the first frame update
    void Start()
    {
        MManager = FindObjectOfType<MusicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTrack()
    {
        MManager.ChangeMusic(newTrack);
    }

}
