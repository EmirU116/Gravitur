using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomLetter : MonoBehaviour
{
    [Header("UI Text")] 
    [SerializeField] private GameObject noteCanvas;

    [SerializeField] private TMP_Text noteTextUI;
    [SerializeField] private string noteText;

    [SerializeField] private UnityEvent openEvent;
    private bool isOpen = false;

    public void ShowNote()
    {
        noteTextUI.text = noteText;
        noteCanvas.SetActive(true);
        openEvent.Invoke();

        isOpen = true;
    }

    public void DisableNote()
    {
        noteCanvas.SetActive(false);
        noteTextUI.text = null;

        isOpen = false;
    }
}
