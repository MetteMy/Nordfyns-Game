using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioClip[] footstepSounds;
    public AudioClip backgroundMusicClip;  // The background music clip

    private AudioSource audioSource;       // AudioSource for sound effects
    private AudioSource musicSource;       // Separate AudioSource for music

    public float footstepDelay = 0.5f;
    private float footstepTimer;

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

        // Ensure two AudioSources are added
        AudioSource[] sources = GetComponents<AudioSource>();
        if (sources.Length < 2)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            musicSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            audioSource = sources[0];
            musicSource = sources[1];
        }

        // Setup music source
        musicSource.loop = true;   // Music should loop
        musicSource.clip = backgroundMusicClip;
    }

    private void Start()
    {
        PlayBackgroundMusic();  // Start playing background music at game start
    }

    private void Update()
    {
        if (footstepTimer > 0)
        {
            footstepTimer -= Time.deltaTime;
        }
    }

    public void PlayFootstepSound()
    {
        if (footstepSounds.Length > 0 && footstepTimer <= 0)
        {
            int index = Random.Range(0, footstepSounds.Length);
            audioSource.PlayOneShot(footstepSounds[index]);
            footstepTimer = footstepDelay;
        }
    }

    public void PlayBackgroundMusic()
    {
        if (musicSource.clip != null)
            musicSource.Play();
    }

    // Additional methods for controlling music
    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }

    public void PauseBackgroundMusic()
    {
        musicSource.Pause();
    }

    public void ResumeBackgroundMusic()
    {
        musicSource.UnPause();
    }
}
