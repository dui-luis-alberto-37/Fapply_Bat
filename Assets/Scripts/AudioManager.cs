using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip inGameMusic;
    public AudioClip menuMusic;
    public AudioClip jump;
    public AudioClip death;
    public AudioClip score;
    public static AudioManager Instance;

void Awake()
{
    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // if (SceneManager.GetActiveScene().buildIndex == 1)
        //     backgroundMusicSource.clip = inGameMusic;
        // else
        //     backgroundMusicSource.clip = menuMusic;
        // backgroundMusicSource.Play();
    }

    // Update is called once per frame
    public void SFXPlay(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void BGPlay(AudioClip clip)
    {
        if (backgroundMusicSource.clip == clip) return;
        
        backgroundMusicSource.clip = clip;
        backgroundMusicSource.Play();
    }
}
