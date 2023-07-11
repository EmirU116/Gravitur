using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class NoteScript : MonoBehaviour
{
    private bool isNoteOpen;
    public TMP_Text messageNote;
    public Canvas noteUI;

    public string note;

    private Interactor _interactor;

    public void Update()
    {
        messageNote.text = note;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _interactor.showLetter = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _interactor.showLetter = false;
        }
    }

    public void ShowNote()
    {
        noteUI.enabled = true;
    }

    public void DisableNote()
    {
        noteUI.enabled = false;
    }
}
