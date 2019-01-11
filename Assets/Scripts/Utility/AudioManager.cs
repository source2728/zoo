using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager inst;

    private Dictionary<string, AudioClip> _soundDictionary;

    private AudioSource bgAudioSource;
    private AudioSource audioSourceEffect;

    void Awake()
    {
        inst = this;

        _soundDictionary = new Dictionary<string, AudioClip>();

        //本地加载 
        AudioClip[] audioArray = Resources.LoadAll<AudioClip>("AudioCilp");
        foreach (AudioClip item in audioArray)
        {
            _soundDictionary.Add(item.name, item);
        }

        bgAudioSource = gameObject.AddComponent<AudioSource>();
        bgAudioSource.volume = 0.1f;
        bgAudioSource.loop = true;
        audioSourceEffect = gameObject.AddComponent<AudioSource>();
    }

    //播放背景音乐
    public void PlayBgAudio(string audioName)
    {
        if (_soundDictionary.ContainsKey(audioName))
        {
            bgAudioSource.clip = _soundDictionary[audioName];
            bgAudioSource.Play();
        }
    }

    public void StopBgAudio()
    {
        if (bgAudioSource != null && bgAudioSource.isPlaying)
        {
            bgAudioSource.Stop();
        }
    }

    //播放音效
    public void PlayAudioEffect(string audioEffectName, bool isRestart = true)
    {
        if (_soundDictionary.ContainsKey(audioEffectName))
        {
            if (isRestart || audioSourceEffect.clip == null || audioSourceEffect.clip.name != audioEffectName || !audioSourceEffect.isPlaying)
            {
                audioSourceEffect.clip = _soundDictionary[audioEffectName];
                audioSourceEffect.Play();
            }
        }
    }
}