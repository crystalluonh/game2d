using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float changeDirectionTime = 3f;

    private Animator animator;
    private Vector3 moveDirection;
    private float timer;

    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeDirection();
    }

    void Update()
    {
        // Di chuyển bot
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Cập nhật speed cho Animator
        animator.SetFloat("speed", moveSpeed);

        // Đếm thời gian và thay đổi hướng ngẫu nhiên
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            ChangeDirection();
            timer = 0;
        }
    }

    void ChangeDirection()
    {
        // Tạo một hướng ngẫu nhiên
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        moveDirection = new Vector3(randomX, 0, randomZ).normalized;
    }
}
