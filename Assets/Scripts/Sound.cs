
using UnityEngine;
using System;
using UnityEngine.Audio;
 [Serializable]
public class Sound
{
    public string name;
    [HideInInspector]
    public AudioSource audioSource;
    public AudioClip audioClip;
    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;
}
