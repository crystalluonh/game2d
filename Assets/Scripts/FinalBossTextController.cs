using System.Collections;
using UnityEngine;

public class FinalBossTextController : MonoBehaviour
{
    [SerializeField] private GameObject finalBossText;  // Drag FinalBossText object into this field in the Inspector.
    [SerializeField] private float displayDuration = 5f; // Thời gian hiển thị (5 giây)

    private void Start()
    {
        // Đảm bảo ban đầu nó không hiển thị
        finalBossText.SetActive(false);

        // Gọi để hiển thị "Final Boss" khi cảnh bắt đầu
        ShowFinalBossText();
    }

    public void ShowFinalBossText()
    {
        // Hiển thị canvas
        finalBossText.SetActive(true);

        // Ẩn sau thời gian delay
        StartCoroutine(HideFinalBossTextAfterDelay());
    }

    private IEnumerator HideFinalBossTextAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        finalBossText.SetActive(false);
    }
}
