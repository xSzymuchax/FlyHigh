using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public bool musicActive = true;
    public bool effectsActive = true;

    public GameObject musicEnabled;
    public GameObject musicDisabled;

    public GameObject effectsEnabled;
    public GameObject effectsDisabled;

    public AudioSource musicSource;

    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip music4;

    public AudioClip activeMusic;

    public static SoundController instance;

    private void Start()
    {
        instance = this;
        activeMusic = music1;
        musicSource.clip = activeMusic;
        musicSource.Play();
    }

    public void ChangeMusicState()
    {
        musicActive = !musicActive;
        
        if (musicActive)
            musicSource.volume = 1;
        else
            musicSource.volume = 0;

        musicEnabled.SetActive(musicActive);
        musicDisabled.SetActive(!musicActive);
    }

    public void ChangeEffectsState()
    {
        effectsActive = !effectsActive;

        effectsEnabled.SetActive(effectsActive);
        effectsDisabled.SetActive(!effectsActive);

    }

    public void ChangeMusic(AudioClip audioClip)
    {
        musicSource.Stop();
        musicSource.clip = audioClip;
        musicSource.Play();
    }
}
