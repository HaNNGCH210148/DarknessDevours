using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    /* void Start()
     {

     }*/

    public Animator animator;                 // Animator của nhân vật (Mixamo)
    public CharacterController controller;    // CharacterController của Player

    private bool isRunning = false;           // Trạng thái chạy/đứng
    void Update()
    {
        // Lấy vận tốc theo XZ (bỏ trục Y vì gravity)
        Vector3 horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);
        float speed = horizontalVelocity.magnitude;

        // Đặt ngưỡng nhỏ để tránh lúc đứng vẫn bị tính là di chuyển
        if (speed < 0.1f) speed = 0;

        // Gửi giá trị sang Animator
        animator.SetFloat("Speed", speed);

        // Kiểm tra điều kiện chạy/đứng
        if (!isRunning && speed > 0)
        {
            isRunning = true;
            animator.SetBool("IsRunning", true);
        }
        else if (isRunning && speed == 0)
        {
            isRunning = false;
            animator.SetBool("IsRunning", false);
        }
    }
}
