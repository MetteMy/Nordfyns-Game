using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioClip[] footstepSounds;
    public AudioClip backgroundMusicClip;  

    public AudioClip BossMusic;

    private AudioSource audioSource;       
    private AudioSource musicSource;       

    public float footstepDelay = 0.5f;
    private float footstepTimer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }

   
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

      
        musicSource.loop = true;   
        musicSource.clip = backgroundMusicClip;
    }

    private void Start()
    {
        PlayBackgroundMusic();  
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
        musicSource.clip = backgroundMusicClip;
        if (musicSource.clip != null){
            musicSource.Play();}
    }

 
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

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayBossMusic(){
        musicSource.clip = BossMusic;
        if (musicSource.clip != null){
            musicSource.Play();
    }}


    public void PlayMusic(AudioClip Music){
        musicSource.clip = Music;
        if (musicSource.clip != null){
            musicSource.Play();
    }
    }
}
