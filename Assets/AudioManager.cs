using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public AudioSource backgroundMusic;
    public static AudioManager instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            SoundNotFound(name);
            return;
        }
        sound.source.Play();
    }

    public void SetBackgroundMusic(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            SoundNotFound(name);
            return;
        }
        backgroundMusic.clip = sound.clip;
        backgroundMusic.Play();
    }

    private void SoundNotFound(string name)
    {
        Debug.LogWarning("Sound: " + name + " not found!");
    }
}
