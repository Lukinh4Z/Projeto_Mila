using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    BUTTON,
    START,
    SHOT,
    ENEMYDEATH,
    PLAYERDEATH,
    ENGINE,
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        //Como PlaySound � 'static' e audioSource n�o �, � preciso acessar a inst�ncia primeiro
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);

    }
}
