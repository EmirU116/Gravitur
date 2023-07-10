using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGPT : MonoBehaviour
{
    [Header("Animation")] 
    public Animation doorOpening;
    public Animation closeDoor;

    [Header("Interaction")] 
    public GameObject keyMesh;
    public GameObject secretWall;
    public GameObject objectiveObject;

    [SerializeField] private bool hasKey;
    private float rotationAngle = 90f;
    private GameObject currentInteractable; // The currently interactable object
    private Transform door;

    [SerializeField] private bool doorOpen;
    [SerializeField] private bool accessible;

    [Header("UI")] public Canvas displayer;
    public GameObject letterDisplayer;
    public Canvas letterUI;
    [SerializeField] private bool showLetter;

    private void Update()
    {
        CheckInteractionInput();

        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleLetterDisplay();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            DisableLetterUI();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            currentInteractable = other.gameObject;
        }

        if (hasKey && other.CompareTag("Door"))
        {
            accessible = true;
            displayer.enabled = true;
        }

        if (other.CompareTag("Letter"))
        {
            showLetter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentInteractable)
        {
            currentInteractable = null;
        }

        if (other.CompareTag("Door"))
        {
            if (doorOpen)
            {
                CloseDoor();
                doorOpen = false;
                accessible = false;
                displayer.enabled = false;
            }

            if (accessible)
            {
                accessible = false;
                displayer.enabled = false;
            }
        }

        if (other.CompareTag("Letter"))
        {
            showLetter = false;
        }
    }

    private void CheckInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentInteractable != null)
            {
                InteractWithObject(currentInteractable);
            }

            if (accessible)
            {
                OpenDoor();
                doorOpen = true;
                hasKey = false;
            }
        }
    }

    private void InteractWithObject(GameObject interactable)
    {
        Debug.Log("Interacting with " + interactable.name);

        interactable.SetActive(false);

        if (interactable.name == "Key")
        {
            hasKey = true;
        }

        if (interactable.name == "Cylinder")
        {
            secretWall.SetActive(false);
        }
    }

    private void OpenDoor()
    {
        doorOpening.Play("OpenDoor");
    }

    private void CloseDoor()
    {
        closeDoor.Play("CloseDoor");
    }

    private void ToggleLetterDisplay()
    {
        if (showLetter)
        {
            letterDisplayer.SetActive(false);
            letterUI.enabled = true;
            showLetter = false;
        }
    }

    private void DisableLetterUI()
    {
        if (letterUI.enabled == true)
        {
            letterUI.enabled = false;
        }
    }
}