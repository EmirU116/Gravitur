using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float interactionDistance = 2f;   // The maximum distance to interact with objects

    [Header("Animation")] 
    public Animation doorOpening;
    public Animation closeDoor;
    
    [Header("Interaction")]
    private float rotationAngle = 90f;
    private GameObject currentInteractable;  // The currently interactable object
    public  GameObject DoorObject;
    private Transform Door;
    [SerializeField] private bool doorOpen;

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

            if (doorOpen)
            {
                OpenDoor();
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

        if (other.CompareTag("Door"))
        {
            doorOpen = true;
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

        if (other.CompareTag("Door"))
        {
            doorOpen = false;
            CloseDoor();
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
