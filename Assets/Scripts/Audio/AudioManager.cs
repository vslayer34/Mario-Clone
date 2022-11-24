using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Debug.LogWarning("Audio Manager instance failed to instancize");
            Destroy(gameObject);
        }

        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.loop = sound.audioSource.loop;
            sound.audioSource.volume = sound.audioSource.volume;
            sound.audioSource.pitch = sound.audioSource.pitch;
        }


    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        sound.audioSource.Play();
        if (sound == null)
        {
            Debug.LogWarning($"Sound: {name} not foud");
        }
    }
}
