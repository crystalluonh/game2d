using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirFloat = 2f;
    [SerializeField] private float attackRange = 0f;
    [SerializeField] private MonoBehaviour enemyType;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private bool stopMovingWhileAttacking = false;
    [SerializeField] private int damageAmount = 10;  // Lượng sát thương gây ra cho người chơi

    private bool canAttack = true;

    private enum State
    {
        Roaming,
        Attacking
    }

    private Vector2 roamPosition;
    private float timeRoaming = 0f;

    private State state;
    private BossPathfinding BossPathfinding;

    private void Awake()
    {
        BossPathfinding = GetComponent<BossPathfinding>();
        state = State.Roaming;  // Ban đầu ở trạng thái Roaming
    }

    private void Start()
    {
        // Không bắt đầu roaming ngay lập tức
        roamPosition = GetRoamingPosition();  // Chuẩn bị sẵn vị trí
    }

    private void Update()
    {
        MovementStateControl();
    }

    private void MovementStateControl()
    {
        switch (state)
        {
            default:
            case State.Roaming:
                Roaming();
                break;

            case State.Attacking:
                Attacking();
                break;
        }
    }

    // Hàm này được gọi từ Animation Event khi animation Start kết thúc
    public void StartRoaming()
    {
        state = State.Roaming;
    }

    private void Roaming()
    {
        timeRoaming += Time.deltaTime;

        BossPathfinding.MoveTo(roamPosition);

        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) < attackRange)
        {
            state = State.Attacking;
        }

        if (timeRoaming > roamChangeDirFloat)
        {
            roamPosition = GetRoamingPosition();
            timeRoaming = 0f;
        }
    }

    private void Attacking()
    {
        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) > attackRange)
        {
            state = State.Roaming;
        }

        if (attackRange != 0 && canAttack)
        {
            canAttack = false;
            (enemyType as IEnemy).Attack();

            if (stopMovingWhileAttacking)
            {
                BossPathfinding.StopMoving();
            }
            else
            {
                BossPathfinding.MoveTo(roamPosition);
            }

            StartCoroutine(AttackCooldownRoutine());
        }
    }

    private IEnumerator AttackCooldownRoutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    // Phương thức để gây sát thương cho người chơi
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && state == State.Attacking)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                Debug.Log("nhandame");
                playerHealth.TakeDamage(damageAmount,other.transform);
            }
        }
    }
}
