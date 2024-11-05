using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip playerSlash;
    public AudioClip enemyDeath;
    public AudioClip dash;

    private static AudioManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Hủy bỏ bản sao mới
            return;
        }

        // Đặt instance là this và đảm bảo không bị phá hủy khi chuyển cảnh
        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
