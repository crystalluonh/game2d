using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFXSource;

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

    // Phát SFX
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    // Đặt âm lượng cho Music (Nhạc nền)
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume; // Thay đổi âm lượng nhạc nền
    }

    // Đặt âm lượng cho SFX (Hiệu ứng âm thanh)
    public void SetSFXVolume(float volume)
    {
        SFXSource.volume = volume; // Thay đổi âm lượng SFX
    }
}
