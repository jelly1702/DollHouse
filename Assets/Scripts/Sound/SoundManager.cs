using UnityEngine;
using UnityEngine.Audio;

public enum PlayerSfxSound
{
    Step = 0,
    Die,
    Hit
}

public enum MonsterSfxSound
{
    Attack = 0,
    Die,
    Hit
}



public class SoundManager : Singleton<SoundManager>
{
    [Header("AudioSource")]
    public AudioSource backgroundSource;
    public AudioSource sfxSource;
    [Header("AudioClip")]
    public AudioClip backgroundClip;
    public AudioClip[] playerSfxClips;
    public AudioClip[] playerStepSfxClips;
    public AudioClip[] monsterSfxClips;
    public AudioClip[] monsterAttackSfxClips;
    [Header("AudioMixer")]
    public AudioMixerGroup backgroundMixerGroup;
    public AudioMixerGroup sfxMixerGroup;

    private void Start()
    {
        if (backgroundSource == null)
        {
            backgroundSource = gameObject.AddComponent<AudioSource>();
            backgroundSource.outputAudioMixerGroup = backgroundMixerGroup;
            backgroundSource.loop = true;
            backgroundSource.clip = backgroundClip;
            backgroundSource.Play();
        }

        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.outputAudioMixerGroup = sfxMixerGroup;
        }
    }

    public void PlayPlayerSFX(PlayerSfxSound sfxSound)
    {
        if (sfxSource != null)
        {
            if (sfxSound == PlayerSfxSound.Step)
            {
                int randomIndex = Random.Range(0, playerStepSfxClips.Length);
                sfxSource.PlayOneShot(playerStepSfxClips[randomIndex]);
            }
        }
    }

    public void PlayMonsterSFX(MonsterSfxSound sfxSound)
    {
        if (sfxSource != null)
        {
            if (sfxSound == MonsterSfxSound.Attack)
            {
                int randomIndex = Random.Range(0, monsterAttackSfxClips.Length);
                sfxSource.PlayOneShot(monsterAttackSfxClips[randomIndex]);
            }
            else
            {
                sfxSource.PlayOneShot(monsterSfxClips[(int)sfxSound]);
            }
        }
    }
}
