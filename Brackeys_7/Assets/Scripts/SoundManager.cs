using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public enum SoundEffect
{
    Click,
    Message,
    PopUp,
    Success
};

public class SoundManager : MonoBehaviour
{
    [Header("AudioSources")]
    [SerializeField]
    private AudioSource audioSource;

    [Header("Sound Effects")]
    [SerializeField]
    private AudioClip[] click;
    [SerializeField]
    private AudioClip[] message;
    [SerializeField]
    private AudioClip[] popUp;
    [SerializeField]
    private AudioClip[] success;
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
        audioSource.PlayOneShot(GetAudioClip(soundEffect), 0.1f);
    }

    private AudioClip GetAudioClip(SoundEffect soundEffect)
    {
        AudioClip[] currentAudioClip = null;

        switch (soundEffect)
        {
            case SoundEffect.Click:
                currentAudioClip = click;
                break;
            case SoundEffect.Message:
                currentAudioClip = message;
                break;
            case SoundEffect.PopUp:
                currentAudioClip = popUp;
                break;
            case SoundEffect.Success:
                currentAudioClip = success;
                break;
        }

        return currentAudioClip[Random.Range(0, currentAudioClip.Length)];
    }
}