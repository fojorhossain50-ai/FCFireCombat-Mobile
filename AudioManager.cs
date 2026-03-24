using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource soundEffectSource;
    public AudioSource musicSource;

    public AudioClip[] soundEffects;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundEffect(int clipIndex)
    {
        if (clipIndex < soundEffects.Length)
        {
            soundEffectSource.clip = soundEffects[clipIndex];
            soundEffectSource.Play();
        }
    }

    public void PlayMusic(AudioClip music)
    {
        musicSource.clip = music;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}