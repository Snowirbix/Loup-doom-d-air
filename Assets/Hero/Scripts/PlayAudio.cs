using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.Q<AudioSource>();
    }

    public void Play()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    
    public void Play(float pitch)
    {
        audioSource.pitch = pitch;
        Play();
    }
}
