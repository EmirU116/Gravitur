using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransisition : MonoBehaviour
{
    public GameObject GO1;
    public GameObject GO2;

    [SerializeField] private bool hasChanged;

    private void Start()
    {
        GO1.SetActive(true);
        GO2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GO1.SetActive(false);
            GO2.SetActive(true);

            hasChanged = true;
        }
    }
}
