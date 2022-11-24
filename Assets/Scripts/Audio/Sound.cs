using System;
using UnityEngine.Audio;
using UnityEngine;

[Serializable]
public class Sound
{
    public AudioClip audioClip;

    public string name;

    [Range(0f, 1.0f)]
    public float volume;

    [Range (0.1f, 3.0f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource audioSource;
}
