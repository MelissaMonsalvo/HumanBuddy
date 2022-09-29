using UnityEngine;
using System;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioClip normalMusic;
    public AudioClip[] chaseMusic;
    private int chaseMaxLevel;
    private int chaseLevel;

    private AudioSource musicAudioSource;
    public static MusicManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance != null)
            Destroy(this.gameObject);
        else
            Instance = this;

    }
    
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
            musicAudioSource.clip = chaseMusic[0];
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
        if (musicAudioSource.clip != chaseMusic[0])
        {
         musicAudioSource.clip = chaseMusic[0];
         musicAudioSource.Play();
        }
           
        if (chaseLevel < chaseMaxLevel)
            chaseLevel++;
    }
}
