using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    
    private void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
    }
}
