using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActive : MonoBehaviour
{
    public float moveSpeed = 2f;      // tốc độ di chuyển
    public float walkTime = 3f;       // thời gian đi
    public float standTime = 2f;      // thời gian đứng

    private Animator animator;
    private float timer = 0f;
    private bool isWalking = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartWalking();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isWalking)
        {
            // di chuyển thẳng
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // khi hết thời gian đi thì dừng lại
            if (timer >= walkTime)
            {
                StartStanding();
            }
        }
        else
        {
            // khi đứng đủ lâu thì quay lại đi tiếp
            if (timer >= standTime)
            {
                StartWalking();
            }
        }
    }

    void StartWalking()
    {
        isWalking = true;
        timer = 0f;

        // random hướng mới mỗi lần đi
        float randomY = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0, randomY, 0);

        animator.SetBool("isWalking", true);
    }

    void StartStanding()
    {
        isWalking = false;
        timer = 0f;

        animator.SetBool("isWalking", false);
        animator.SetTrigger("isStanding");
    }
}
