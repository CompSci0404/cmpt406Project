﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public SoundClass[] sounds;
    // Start is called before the first frame update
    //adds an audio source component to for every sound in the array
    void Awake()
    {
        Debug.Log("we here");
        foreach (SoundClass sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;

        }
    }

    //public method that can be called when a sounds needs to be played
    //name: name of the sound clip
    public void PlaySound(string name)
    {
        //find the sound with the name within the sounds[] that matches the name param
        SoundClass sFound = Array.Find(sounds, sound => sound.name == name);
        sFound.source.Play();
    }
}