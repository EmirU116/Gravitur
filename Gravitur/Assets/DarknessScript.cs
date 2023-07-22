using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DarknessScript : MonoBehaviour
{
    public GameObject darkness;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            darkness.SetActive(true);
        }
    }
}
