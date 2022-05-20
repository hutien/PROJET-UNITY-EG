﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemDoor : MonoBehaviour
{
    public bool doorOpen = false;
    public float doorOpenAngle = 95f;
    public float doorCloseAngle = 0.0f;


    public float smooth = 3.0f;

    public AudioClip openDoor;
    public AudioClip closeDoor;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void ChangeDoorState()
    {
        doorOpen = !doorOpen;

    }





    // Update is called once per frame
    void Update()
    {
        if(doorOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "triggerdoor")
        {
            AudioSource.PlayClipAtPoint(closeDoor, transform.position, 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "triggerdoor")
        {
            AudioSource.PlayClipAtPoint(openDoor, transform.position, 1);
        }
    }


}