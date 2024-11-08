using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EconomyManager : Singleton<EconomyManager>
{
    private TMP_Text goldText;
    private int currentGold = 0;

    const string COIN_AMOUNT_TEXT = "Gold Amount Text";
    const string GOLD_KEY = "CurrentGold";  // Key để lưu số vàng vào PlayerPrefs

    private void Start()
    {
        // Đảm bảo rằng dữ liệu vàng được tải khi cảnh được load
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Tải số vàng từ PlayerPrefs khi game bắt đầu
        LoadGold();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Gọi lại LoadGold để đảm bảo dữ liệu vàng được tải sau mỗi lần chuyển cảnh
        LoadGold();
    }

    public void UpdateCurrentGold()
    {
        currentGold += 1;

        // Cập nhật số vàng trong PlayerPrefs mỗi lần thay đổi
        PlayerPrefs.SetInt(GOLD_KEY, currentGold);
        PlayerPrefs.Save();  // Đảm bảo dữ liệu được lưu lại ngay lập tức

        // Cập nhật giao diện
        if (goldText == null)
        {
            goldText = GameObject.Find(COIN_AMOUNT_TEXT).GetComponent<TMP_Text>();
        }

        goldText.text = currentGold.ToString("D3");

        // Kiểm tra số vàng đã thay đổi chính xác
        Debug.Log("Current Gold: " + currentGold);
    }

    private void LoadGold()
    {
        // Tải số vàng từ PlayerPrefs khi bắt đầu game
        currentGold = PlayerPrefs.GetInt(GOLD_KEY, 0); // Nếu không tìm thấy, trả về 0

        // Cập nhật giao diện
        if (goldText == null)
        {
            goldText = GameObject.Find(COIN_AMOUNT_TEXT).GetComponent<TMP_Text>();
        }
        goldText.text = currentGold.ToString("D3");

        // Kiểm tra khi tải số vàng
        Debug.Log("Loaded Gold: " + currentGold);
    }

    private void OnApplicationQuit()
    {
        // Lưu lại số vàng khi game thoát
        PlayerPrefs.Save();
    }
    private void UpdateGoldDisplay()
    {
        if (goldText == null)
        {
            goldText = GameObject.Find(COIN_AMOUNT_TEXT).GetComponent<TMP_Text>();
        }

        goldText.text = currentGold.ToString("D3");
    }
    public void ResetGold()
    {
        currentGold = 0;  // Reset lại số vàng về 0
        PlayerPrefs.SetInt(GOLD_KEY, currentGold);  // Lưu lại số vàng đã reset
        PlayerPrefs.Save();  // Đảm bảo lưu dữ liệu

        // Cập nhật giao diện
        UpdateGoldDisplay();
    }
}


