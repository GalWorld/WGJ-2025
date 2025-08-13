using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioSource audioSource;
    public AudioClip mainTheme;
    public AudioClip gameOverTheme;
    public AudioClip CatTheme;
    public AudioClip AnimalTheme;
    public AudioSource Brillitos;

    private void Awake()
    {
        // Singleton para evitar duplicados
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

    void Start()
    {
        audioSource.clip = mainTheme;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayGameOverMusic()
    {
        StartCoroutine(FadeOutAndPlayNew(gameOverTheme));
    }

    public void PlayCatMusic()
    {
        StartCoroutine(FadeOutAndPlayNew(CatTheme));
    }

    public void PlayAnimalMusic()
    {
        StartCoroutine(FadeOutAndPlayNew(AnimalTheme));
    }

    private IEnumerator FadeOutAndPlayNew(AudioClip newClip)
    {
        // Fade out
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime;
            yield return null;
        }

        // Cambia la música
        audioSource.clip = newClip;
        audioSource.loop = false;
        audioSource.Play();

        // Fade in
        while (audioSource.volume < startVolume)
        {
            audioSource.volume += startVolume * Time.deltaTime;
            yield return null;
        }
    }

    public void PlayMainTheme()
    {
        StartCoroutine(FadeOutAndPlayNew(mainTheme));
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && Brillitos != null)
        {
            Brillitos.PlayOneShot(clip);
        }
    }
}

