using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioMixerGroup generalMixer;
    public Sounds[] sounds;
    [SerializeField] public AudioMixerGroup musicMixer, soundMixer;
    public bool musicMute;
    public bool soundMute;

    private void Awake()
    {
        
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);


        musicMixer.audioMixer.SetFloat("MusicVol", (Mathf.Log10(SaveSystem.data.mscVol) * 20));
        soundMixer.audioMixer.SetFloat("SoundVol", (Mathf.Log10(SaveSystem.data.sndVol) * 20));
        foreach (Sounds sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.loop = sound.loop;
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.outputAudioMixerGroup = generalMixer;
            sound.audioSource.playOnAwake = false;
            if (sound.bgm == true)
            {
                sound.audioSource.outputAudioMixerGroup = musicMixer;
            }
            else
            {
                sound.audioSource.outputAudioMixerGroup = soundMixer;
            }

        }
    }

    public void Play(string name, Sounds[] arrayType)
    {
        Sounds sounds = System.Array.Find(arrayType, sound => sound.name == name);
        if (sounds == null)
        {
            Debug.Log("The sound " + name + " couldn't be found");
            return;
        }
        sounds.audioSource.Play();
    }

    public void Pause(string name, Sounds[] arrayType)
    {
        Sounds sounds = System.Array.Find(arrayType, sound => sound.name == name);
        if (sounds == null)
        {
            Debug.Log("The sound " + name + " couldn't be found");
            return;
        }
        sounds.audioSource.Pause();
    }

    public void UnPause(string name, Sounds[] arrayType)
    {
        Sounds sounds = System.Array.Find(arrayType, sound => sound.name == name);
        if (sounds == null)
        {
            Debug.Log("The sound " + name + " couldn't be found");
            return;
        }
        sounds.audioSource.UnPause();
    }

    public void UpdatePlay(string name, Sounds[] arrayType)
    {
        Sounds sounds = System.Array.Find(arrayType, sound => sound.name == name);
        if (sounds == null)
        {
            Debug.Log("The sound " + name + " couldn't be found");
            return;
        }

        if (!sounds.audioSource.isPlaying)
            sounds.audioSource.Play();

        sounds.audioSource.Pause();
        sounds.audioSource.UnPause();
    }

    public void Stop(string name, Sounds[] arrayType)
    {
        Sounds sounds = System.Array.Find(arrayType, sound => sound.name == name);
        if (sounds == null)
        {
            Debug.Log("The sound " + name + " couldn't be found");
            return;
        }
        sounds.audioSource.Stop();
    }


}