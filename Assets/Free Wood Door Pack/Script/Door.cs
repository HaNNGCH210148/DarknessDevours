using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DoorScript
{
    [RequireComponent(typeof(AudioSource))]


    public class Door : MonoBehaviour
    {
        public bool open = false;
        public float smooth = 1.0f;
        float DoorOpenAngle = -90.0f;
        float DoorCloseAngle = 0.0f;
        public AudioSource asource;
        public AudioClip openDoor, closeDoor;
        // Use this for initialization
        void Start()
        {
            asource = GetComponent<AudioSource>();
            open = false; // Ensure door is closed at start
        }

        void Update()
        {
            // Listen for E key to open the door
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (open) 
                    CloseDoor();
                else 
                    OpenDoor();
            }

            if (open)
            {
                var target = Quaternion.Euler(0, DoorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);
            }
            else
            {
                var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * 5 * smooth);
            }
        }

        public void OpenDoor()
        {
            open = true;
            asource.clip = openDoor;
            asource.Play();
        }
        public void CloseDoor()
        {
            open = false;
            asource.clip = closeDoor;
            asource.Play();
        }
    }
}