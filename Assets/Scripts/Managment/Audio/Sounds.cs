using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sounds 
{
    public string name;
    public AudioClip audioClip;
    public bool loop;
    public bool bgm;
    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 1f)]
    public float pitch;

    [HideInInspector]
    public AudioSource audioSource;
}
