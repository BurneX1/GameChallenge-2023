using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class AudioButtons : MonoBehaviour
{
    public bool msc;
    //public Button onMute;
    //public Button onUnMute;
    public Slider sld;
    // Start is called before the first frame update
    void Awake()
    {
        UISetUp();
    }

    void UISetUp()
    {
        if (msc)
        {
            if(sld)
            {
                sld.value = SaveSystem.data.mscVol;
            }
        }
        else
        {
            if (sld)
            {
                sld.value = SaveSystem.data.sndVol;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGlobalVolume(float volumeVal)
    {
        AudioManager.Instance.generalMixer.audioMixer.SetFloat("GlobalVol", Mathf.Log10(volumeVal) * 20);
        SaveSystem.Save();
    }

    public void SetMusicVolume(float volumeVal)
    {
        if (AudioManager.Instance.musicMute)
        {
            AudioManager.Instance.musicMixer.audioMixer.SetFloat("MusicVol", -80);
        }
        else
        {
            if (volumeVal <= 0)
            {
                volumeVal = 0.001f;
            }
            AudioManager.Instance.musicMixer.audioMixer.SetFloat("MusicVol", (Mathf.Log10(volumeVal) * 20));
            SaveSystem.data.mscVol = volumeVal;
            

        }
        SaveSystem.Save();
    }


    public void SetSoundVolume(float volumeVal)
    {
        if (AudioManager.Instance.soundMute)
        {
            AudioManager.Instance.soundMixer.audioMixer.SetFloat("SoundVol", -80);
        }
        else
        {
            if(volumeVal <= 0)
            {
                volumeVal = 0.001f;
            }
            AudioManager.Instance.soundMixer.audioMixer.SetFloat("SoundVol", (Mathf.Log10(volumeVal) * 20));
            SaveSystem.data.sndVol = volumeVal;

        }
        SaveSystem.Save();
    }

    public void MuteMusic(bool value)
    {
        AudioManager.Instance.musicMute = value;
        SaveSystem.data.mscMute = value;
        SetMusicVolume(SaveSystem.data.mscVol);

    }

    public void MuteSound(bool value)
    {
        AudioManager.Instance.soundMute = value;
        SaveSystem.data.sndMute = value;
        SetSoundVolume(SaveSystem.data.sndVol);
 

    }

    public void CallSound(string nameSong)
    {
        AudioManager.Instance.Play(nameSong, AudioManager.Instance.sounds);
    }
}
