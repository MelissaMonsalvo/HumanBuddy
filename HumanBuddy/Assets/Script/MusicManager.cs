using UnityEngine;
using System;

public class MusicManager : MonoBehaviour
{
    public AudioClip normalMusic;
    public AudioClip[] chaseMusic;
    private int chaseMaxLevel;
    private int chaseLevel;

    private AudioSource musicAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        musicAudioSource = GetComponent<AudioSource>();
        chaseMaxLevel = chaseMusic.Length - 1;
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayingEvent += PlayMusic;
            GameManager.Instance.PauseEvent += StopMusic;
            GameManager.Instance.GameOverEvent += StopMusic;
        }
    }
    public void PlayMusic(object sender, EventArgs e)
    {
        musicAudioSource.clip = normalMusic;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }
    public void StopMusic(object sender, EventArgs e)
    {
        musicAudioSource.Stop();
    }

    public void PatrolEventResponse()
    {
        if (chaseLevel > 0)
        {
            chaseLevel--;
            musicAudioSource.clip = chaseMusic[chaseLevel];
            musicAudioSource.Play();
        }
        else
        {
            if (musicAudioSource.clip != normalMusic)
            {
                musicAudioSource.clip = normalMusic;
                musicAudioSource.Play();
            }
        }

    }
    public void ChaseEventResponse()
    {
        musicAudioSource.clip = chaseMusic[chaseLevel];
        musicAudioSource.Play();
        if (chaseLevel < chaseMaxLevel)
            chaseLevel++;
    }
}
