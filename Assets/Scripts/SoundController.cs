using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SoundController:MonoBehaviour
{
    public static AudioClip scarabSound, blipSound,completedSound;
    static AudioSource audioSource;
   void Start()
    {
        scarabSound = Resources.Load<AudioClip>("Sounds/Scarab");
        blipSound = Resources.Load<AudioClip>("Sounds/Blip");
        completedSound = Resources.Load<AudioClip>("Sounds/Completed");
        audioSource = GetComponent<AudioSource>();
    }

 public static void playSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
