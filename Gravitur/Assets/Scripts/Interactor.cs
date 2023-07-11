using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    [Header("Animation")] 
    public Animation doorOpening;
    public Animation closeDoor;

    [Header("Interaction")] 
    public GameObject keyMesh;
    public GameObject secretWall;
    public GameObject ObjectiveObject;

    [SerializeField] private bool hasKey;
    
    private float rotationAngle = 90f;
    private GameObject currentInteractable;  // The currently interactable object
    private Transform Door;

    [SerializeField] private bool doorOpen;
    [SerializeField] private bool accessable;

    [Header("UI")] 
    public Canvas Displayer;

    public NoteScript ns;


    void Update()
    {
        // Check for interaction input
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if there is a current interactable object
            if (currentInteractable != null)
            {
                // Interact with the object
                InteractWithObject(currentInteractable);
            }
            // Opens the door
            if (accessable)
            {
                OpenDoor();
                doorOpen = true;
                hasKey = false;
            }
        }

        // if (Input.GetKeyDown(KeyCode.F))
        // {
        //     if (ns.canOpen)
        //     {
        //         ns.isRead = true;
        //         ns.UI.enabled = true;
        //     }
        // }

    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the entering object is interactable
        if (other.CompareTag("Interactable"))
        {
            // Store the reference to the current interactable object
            currentInteractable = other.gameObject;
        }
        // Gets accessibility when in the collider
        if (hasKey && other.CompareTag("Door"))
        {
            accessable = true;
            Displayer.enabled = true;
        }

        // if (other.CompareTag("Letter"))
        // {
        //     ns.isRead = true;
        // }

    }

    void OnTriggerExit(Collider other)
    {
        // Check if the exiting object is the current interactable object
        if (other.gameObject == currentInteractable)
        {
            // Clear the reference to the current interactable object
            currentInteractable = null;
        }
        // Checks if the existing object has the tag Door
        if (other.CompareTag("Door"))
        {
            // Closes door when going away from it
            if (doorOpen)
            {
                CloseDoor();
                doorOpen = false;
                accessable = false;
                Displayer.enabled = false;
            }
            // This is for so that closing door animation is not playing when going away only from door
            if (accessable)
            {
                accessable = false;
                Displayer.enabled = false;
            }
        }

        // if (other.CompareTag("Letter"))
        // {
        //     if (ns.canOpen)
        //     {
        //         ns.canOpen = false;
        //     }
        // }
    }

    void InteractWithObject(GameObject interactable)
    {
        // Perform the interaction with the object
        Debug.Log("Interacting with " + interactable.name);

        // TODO: Implement your interaction logic here
        // Finding key logic for unlocking door
        interactable.SetActive(false);
        
        // Interacting with key
        if (interactable.name == "Key")
        {
            hasKey = true;
        }
        // Objectives for finding the key
        if (interactable.name == "Cylinder")
        {
            secretWall.SetActive(false);
        }
    }

    void OpenDoor()
    {
        // playing open animation
        doorOpening.Play("OpenDoor");
    }

    void CloseDoor()
    {
        // playing closing animation
        closeDoor.Play("CloseDoor");
    }

    void SecretWall()
    {
        // play animation for secret door
    }
}
