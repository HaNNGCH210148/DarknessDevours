using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorNotiText : MonoBehaviour
{
    public Animator doorAnimator;
    public AudioSource audioSource;
    public TextMeshProUGUI interactText; // Kéo UI Text vào đây trong Inspector

    private bool isPlayerNear = false;
    private bool isOpen = false;

    void Start()
    {
        interactText.gameObject.SetActive(false); // Ẩn text lúc đầu
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (!isOpen)
            {
                doorAnimator.SetTrigger("Door_Open");
                audioSource.Play();
                isOpen = true;
                interactText.text = "Press E to Close Door";
            }
            else
            {
                doorAnimator.SetTrigger("Door_Close");
                audioSource.Play();
                isOpen = false;
                interactText.text = "Press E to Open Door";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.gameObject.SetActive(true);
            interactText.text = isOpen ? "Press E to Close Door" : "Press E to Open Door";
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.gameObject.SetActive(false);
            isPlayerNear = false;
        }
    }
}
