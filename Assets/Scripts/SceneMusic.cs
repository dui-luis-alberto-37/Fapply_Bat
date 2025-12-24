using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    public AudioClip backgroundMusic;

    void Start()
    {
        AudioManager.Instance.BGPlay(backgroundMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
