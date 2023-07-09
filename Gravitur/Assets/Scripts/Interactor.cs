using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [Header("Animation")] 
    public Animation doorOpening;
    public Animation closeDoor;
    
    [Header("Interaction")]
    private float rotationAngle = 90f;
    private GameObject currentInteractable;  // The currently interactable object
    //public  GameObject DoorObject;
    private Transform Door;
    [SerializeField] private bool doorOpen;
    [SerializeField] private bool accessable;

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
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the entering object is interactable
        if (other.CompareTag("Interactable"))
        {
            // Store the reference to the current interactable object
            currentInteractable = other.gameObject;
        }
        // Gets accessability when in the collider
        if (other.CompareTag("Door"))
        {
            accessable = true;
        }
        
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
            }
            // This is for so that closing door animation is not playing when going away only from door
            if (accessable)
            {
                accessable = false;
            }
        }
        
    }

    void InteractWithObject(GameObject interactable)
    {
        // Perform the interaction with the object
        Debug.Log("Interacting with " + interactable.name);

        // TODO: Implement your interaction logic here
        Destroy(interactable);

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
}
