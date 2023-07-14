using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransisition : MonoBehaviour
{
    public GameObject GO1;  // scene 1
    public GameObject GO2;  // scene 2 

    [SerializeField] private bool hasChanged;   

    private void Start()
    {
        // starting the game with first scene
        GO1.SetActive(true);    
        GO2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // when player is entering the collider, it will make transition from scene 1 to scene 2 quite smoothly
        if (other.CompareTag("Player"))
        {
            GO1.SetActive(false);
            GO2.SetActive(true);

            hasChanged = true;
        }
    }
}
