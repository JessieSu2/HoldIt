using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] public AudioSource _musicSource, _effectsSource;

    [Header("Music")]
    [SerializeField] AudioClip mainPageMusic;
    [SerializeField] AudioClip gameBackgroundMusic;
    [SerializeField] AudioClip storybookMusic;
    

    [Header("SoundEffects")]
    [SerializeField] AudioClip ewwSound;
    [SerializeField] AudioClip bulpSound;
    [SerializeField] AudioClip fartSound;
    [SerializeField] AudioClip poopSound;
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip levelCompleteSound;
    [SerializeField] AudioClip failLevelSound;
    [SerializeField] AudioClip tummyGrumbleSound;

    public enum Music
    {
        MainPageMusic,
        GameBackgroundMusic,
        StorybookMusic
    }

    public enum SoundEffects
    {
        EwwSound,
        BulpSound,
        FartSound,
        PoopSound,
        ClickSound,
        LevelCompleteSound,
        FailLevelSound,
        TummyGrumbleSound
    }

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

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic(Music.MainPageMusic);
    }

    private void OnLevelWasLoaded(int level)
    {
        switch (level)
        {
            case 0:
                PlayMusic(Music.MainPageMusic);
                break;
            case 1:
                PlayMusic(Music.StorybookMusic);
                break;
            case 2:
                PlayMusic(Music.GameBackgroundMusic);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(SoundEffects soundEffectName)
    {
        AudioClip clip = FindSoundEffect(soundEffectName);
        _effectsSource.PlayOneShot(clip);
    }

    public void PlayMusic(Music musicName)
    {
        AudioClip clip = FindMusic(musicName);
        _musicSource.clip = clip;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    private AudioClip FindMusic(Music musicName)
    {
        switch (musicName)
        {
            case Music.MainPageMusic:
                return mainPageMusic;
            case Music.StorybookMusic:
                return storybookMusic;
            case Music.GameBackgroundMusic:
                return gameBackgroundMusic;
            default:
                return null;
        }
    }

    private AudioClip FindSoundEffect(SoundEffects soundEffectName)
    {
        switch (soundEffectName)
        {
            case SoundEffects.EwwSound:
                return ewwSound;
            case SoundEffects.BulpSound:
                return bulpSound;
            case SoundEffects.FartSound:
                return fartSound;
            case SoundEffects.PoopSound:
                return poopSound;
            case SoundEffects.LevelCompleteSound:
                return levelCompleteSound;
            case SoundEffects.FailLevelSound:
                return failLevelSound;
            case SoundEffects.ClickSound:
                return clickSound;
            case SoundEffects.TummyGrumbleSound:
                return tummyGrumbleSound;
            default:
                return null;
        }
    }
}
