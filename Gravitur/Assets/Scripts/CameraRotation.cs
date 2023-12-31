using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    // WSAD movemnt
    // Jump
    // Interaction ( E )
    // Gravity Manipultion ( F )

    [Header("Reference")]   // formating in details/inspector
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    //public Rigidbody rigidbody;

    public float rotationSpeed;

    private Vector3 inputDir;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   // locking the cursor the the center?
        Cursor.visible = false;     // hiding the cursor i guess
    }

    private void Update()
    {
        // Calculating where camera and player is to know where forward is
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
        
        // getting the wsad inputs
        float horizontalinput = Input.GetAxis("Horizontal"); // A D movement 
        float veritcalinput = Input.GetAxis("Vertical");    // W S movement
        inputDir = orientation.forward * veritcalinput + orientation.right * horizontalinput;

        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}
