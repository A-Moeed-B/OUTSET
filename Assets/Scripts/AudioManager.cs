
using System;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound currentSound in sounds)
        {
            currentSound.audioSource=gameObject.AddComponent<AudioSource>();
            currentSound.audioSource.clip = currentSound.audioClip;
            currentSound.audioSource.volume = currentSound.volume;
            currentSound.audioSource.pitch = currentSound.pitch;
        }
    }
    public void play(string name)
    {
        Array.Find(sounds, sound => sound.name == name).audioSource.Play();


    }
}
