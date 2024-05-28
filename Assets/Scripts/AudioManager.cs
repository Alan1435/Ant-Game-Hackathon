using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    void Start(){
         Play("Bg"); 

    }
    
    public void Play(string name){

        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.time = 0.0f;
        //Debug.Log(s.source.time);
        s.source.Play();
    }
}
