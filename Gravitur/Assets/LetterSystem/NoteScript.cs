using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class NoteScript : MonoBehaviour
{
    public Canvas UI;
    [TextArea(15, 20)]public string letterMessage;
    public TMP_Text messageText;
    public AudioSource src;
    public AudioClip sfx1, sfx2;

    public bool isRead = false;

    public bool canOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isRead)
        {
            canOpen = true;
            // Display the unique message for this letter on the UI Text component
            messageText.text = letterMessage;
            
            isRead = true;
            UI.enabled = true;

            src.clip = sfx1;
            src.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canOpen = false;
        UI.enabled = false;
    }
    
}
