using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource backgroundMusic;
    public AudioSource waveSound;
    public AudioSource dolphinSound;

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

    private void Start()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.loop = true;
            backgroundMusic.Play();
        }
    }

    public void PlayWaveSound()
    {
        if (waveSound != null)
        {
            waveSound.Play();
        }
    }

    public void PlayDolphinSound()
    {
        if (dolphinSound != null)
        {
            dolphinSound.Play();
        }
    }
}

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dolphin")) // Ensure the dolphin has the tag "Dolphin"
        {
            SoundManager.Instance.PlayDolphinSound();
        }
    }
}
