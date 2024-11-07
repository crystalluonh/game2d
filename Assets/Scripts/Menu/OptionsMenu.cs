using UnityEngine;
using UnityEngine.UI;  // Để sử dụng Slider và Button

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsPanel;  // Panel Options
    public Slider musicSlider;  // Slider cho âm thanh nền
    public Slider sfxSlider;  // Slider cho SFX
    private AudioManager audioManager;  // Lưu tham chiếu đến AudioManager

    void Start()
    {
        // Lấy tham chiếu đến AudioManager
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        // Đặt giá trị mặc định cho các slider từ âm lượng hiện tại
        musicSlider.value = audioManager.musicSource.volume;
        sfxSlider.value = audioManager.SFXSource.volume;

        // Gắn sự kiện cho các slider
        musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
    }

    // Thay đổi âm lượng nhạc nền
    void OnMusicVolumeChanged(float value)
    {
        audioManager.SetMusicVolume(value);  // Cập nhật âm lượng nhạc nền
    }

    // Thay đổi âm lượng SFX
    void OnSFXVolumeChanged(float value)
    {
        audioManager.SetSFXVolume(value);  // Cập nhật âm lượng SFX
    }

    // Mở Options menu
    public void OpenOptions()
    {
        optionsPanel.SetActive(true);  // Hiển thị Options Panel
    }

    // Đóng Options menu
    public void CloseOptions()
    {
        optionsPanel.SetActive(false);  // Ẩn Options Panel
    }
}
