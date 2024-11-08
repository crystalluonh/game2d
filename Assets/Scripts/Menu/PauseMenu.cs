using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;  // Singleton instance
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    void Awake()
    {
        // Kiểm tra và đảm bảo chỉ có 1 instance của PauseMenu trong mỗi scene
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // Nếu đã có instance, hủy đối tượng mới tạo
        }
    }
    



    void Update()
    {
        // Kiểm tra phím Escape để tạm dừng game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Resume game, ẩn menu và tiếp tục game
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);  // Ẩn Pause Menu
        Time.timeScale = 1;  // Tiếp tục game
        isPaused = false;
    }

    // Pause game, hiển thị menu tạm dừng và dừng game
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);  // Hiển thị Pause Menu
        Time.timeScale = 0;  // Dừng game
        isPaused = true;
    }

    // Xử lý khi nhấn nút Quit: Quay về Menu chính hoặc thoát game
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;  // Đảm bảo thời gian game không bị dừng khi chuyển cảnh
    }

    // Khi chuyển cảnh, kiểm tra nếu là menu scene thì xóa PauseMenu
    void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Destroy(gameObject);  // Xóa PauseMenu khi về menu scene
        }
    }
}
