using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsPanel;  // Panel Options
    public GameObject mainMenuPanel; // Panel Menu chính

    public void PlayGame()
    {
        // Chuyển đến scene chơi game, thay "Scene1" bằng tên scene của bạn
        SceneManager.LoadScene("Scene1");
    }

    public void QuitGame()
    {
        Debug.Log("Game is quitting...");

        // Tìm đối tượng Player trong cảnh hiện tại và loại bỏ khỏi DontDestroyOnLoad
        GameObject player = GameObject.FindGameObjectWithTag("Player3");
        if (player != null)
        {
            // Hủy bỏ đối tượng Player
            Destroy(player);
        }

        // Đảm bảo xóa đối tượng Player trước khi chuyển cảnh
        SceneManager.LoadScene("Menu");  // Hoặc scene menu chính của bạn
        Time.timeScale = 1;  // Đảm bảo thời gian game không bị dừng lại khi chuyển cảnh
    }

    public void PauseGame()
    {
        // Nếu game đang chạy, dừng lại (timeScale = 0)
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            Debug.Log("Game Paused");
        }
        // Nếu game đang dừng, tiếp tục (timeScale = 1)
        else
        {
            Time.timeScale = 1;
            Debug.Log("Game Resumed");
        }
    }

    // Hiển thị hoặc ẩn panel Options
    public void ToggleOptions()
    {
        bool isOptionsActive = optionsPanel.activeSelf;
        bool isMainMenuActive = mainMenuPanel.activeSelf;

        // Nếu OptionsPanel chưa hiển thị, ẩn MainMenu và hiển thị OptionsPanel
        if (!isOptionsActive)
        {
            mainMenuPanel.SetActive(false);  // Ẩn menu chính
            optionsPanel.SetActive(true);    // Hiển thị options
        }
        else
        {
            mainMenuPanel.SetActive(true);   // Hiển thị lại menu chính
            optionsPanel.SetActive(false);   // Ẩn options
        }
    }

    // Đóng Options Panel và trở về Main Menu
    public void CloseOptions()
    {
        optionsPanel.SetActive(false);  // Ẩn options
        mainMenuPanel.SetActive(true);  // Hiển thị menu chính
    }
}
