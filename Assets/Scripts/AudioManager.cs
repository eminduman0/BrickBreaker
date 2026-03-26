using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Clips")]
    public AudioClip mainMenuMusic;
    public AudioClip playSound;
    public AudioClip buttonClick;
    public AudioClip ballHit;
    public AudioClip failSound;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayMusic(mainMenuMusic);
        }
    }

    // 🎵 Müzik
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    // 🔊 SFX
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    // 🎮 Play tuşu
    public void PlayGame()
    {
        StopMusic();
        SceneManager.LoadScene("Game");
        PlaySFX(playSound);
    }

    
}