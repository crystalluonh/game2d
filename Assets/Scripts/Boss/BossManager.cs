using UnityEngine;

public class BossScript : MonoBehaviour
{
    private Animator animator;
    private bool canMove = false; // Cờ để kiểm soát việc di chuyển

    

   
    // Hàm được gọi khi animation kết thúc
    public void OnAnimationEnd()
    {
        Debug.Log("Animation ended, starting Idle and enabling movement.");
        animator.Play("Idle");  // Chuyển sang animation Idle
        canMove = true;         // Cho phép di chuyển sau khi animation kết thúc
    }

    
}
