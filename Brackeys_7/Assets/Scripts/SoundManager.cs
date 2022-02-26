using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public enum SoundEffect
{
    Click,
    Close,
    PopUp,
};

public class SoundManager : MonoBehaviour
{
    [Header("AudioSources")]
    [SerializeField]
    private AudioSource sfxAudioSource;

    [Header("Sound Effects")]
    [SerializeField]
    private AudioClip[] click;
    [SerializeField]
    private AudioClip[] close;
    [SerializeField]
    private AudioClip[] popUp;

    public static SoundManager Instance;

    private SoundEffect _soundEffect;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySoundEffect(SoundEffect soundEffect)
    {
        sfxAudioSource.PlayOneShot(GetAudioClip(soundEffect), 0.1f);
    }

    private AudioClip GetAudioClip(SoundEffect soundEffect)
    {
        AudioClip[] currentAudioClip = null;

        switch (soundEffect)
        {
            case SoundEffect.Click:
                currentAudioClip = click;
                break;
            case SoundEffect.Close:
                currentAudioClip = close;
                break;
            case SoundEffect.PopUp:
                currentAudioClip = popUp;
                break;
        }

        return currentAudioClip[Random.Range(0, currentAudioClip.Length)];
    }
}