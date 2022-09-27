
using UnityEngine;
[CreateAssetMenu(fileName = "SFxPlayer", menuName = "Audio/SFxPlayer")]

public class SimpleAudioEvent : AudioEvent
{
    public AudioClip[] sfxClips;
    public override void Play(AudioSource source)
    {
        if (sfxClips.Length == 0)
            return;
        source.clip = sfxClips[Random.Range(0, sfxClips.Length)];
        source.Play();
    }


    public void LPlayHurt(AudioSource source)
    {
        source.PlayOneShot(sfxClips[0]);
    }

    public void LPlayLaught(AudioSource source)
    {
        source.PlayOneShot(sfxClips[1]);
    }

    public void LPlayDeath(AudioSource source)
    {
        source.PlayOneShot(sfxClips[2]);
    }

    public void VPlayHurt(AudioSource source)
    {
        source.PlayOneShot(sfxClips[2]);
    }

    public void VPlayLaught(AudioSource source)
    {
        source.PlayOneShot(sfxClips[3]);
    }
    public void PlayFeedback(AudioSource source)
    {
        source.PlayOneShot(sfxClips[5]);
    }
}
