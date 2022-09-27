using System;
using UnityEngine;

public class SFxManager : MonoBehaviour
{
    public SimpleAudioEvent sFx;
    private AudioSource sfxAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        sfxAudioSource = GetComponent<AudioSource>();
        GameManager.Instance.PauseEvent += PauseEffect;
        GameManager.Instance.GameOverEvent += GameOverEffect;
    }

    public void GameOverEffect(object sender, EventArgs e)
    {
        sFx.LPlayDeath(sfxAudioSource);
    }
    public void PauseEffect(object sender, EventArgs e)
    {
        sFx.PlayFeedback(sfxAudioSource);
    }
}
