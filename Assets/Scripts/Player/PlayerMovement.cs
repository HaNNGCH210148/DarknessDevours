using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
        //public Animator animator;     // kéo Animator c?a Model vào ?ây trong Inspector
        //public Transform model;       // tham chi?u t?i child "Model" ?? xoay m?t (third-person)

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groudDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    //Update iss called one per frame
    void Update()
    {

        //checking if we hit the ground to reset our falling valocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groudDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // right is the red Axis, foward is the blue axis
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //check if the player is on the ground so we can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);




        // 1) G?i t?c ?? cho BlendTree (0..1)
        /* float inputMag = new Vector2(x, z).magnitude;          // 0 (??ng yên) ? 1 (?i nhanh)
        animator.SetFloat("Speed", inputMag, 0.1f, Time.deltaTime); // có damping cho m??t

        // 2) C?p nh?t grounded ?? Animator bi?t khi nào ?ang ? trên ??t
        animator.SetBool("IsGrounded", isGrounded);

        // 3) Khi nh?y, b?n trigger
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger("Jump");
        }

        // 4) (Tùy ch?n) N?u là góc nhìn th? ba: xoay model theo h??ng di chuy?n
        if (model && inputMag > 0.1f)
        {
            Vector3 look = new Vector3(move.x, 0, move.z);
            model.forward = Vector3.Slerp(model.forward, look, 0.15f);
        }*/

    }
}
