using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransisition : MonoBehaviour
{
    public GameObject GO1;  // scene 1
    public GameObject GO2;  // scene 2 

    [SerializeField] private bool hasChanged;

    public GameObject objective;
    public bool objectiveisopen;
    [SerializeField] private Interactor _interactor;

    private void Start()
    {
        // starting the game with first scene
        GO1.SetActive(true);    
        GO2.SetActive(false);
    }

    public void Update()
    {
        // when finding cylinder, it will let you transition back to scene 1 
        if (_interactor.transitionBack)
        {
            objectiveisopen = true;
        }
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

        if (other.CompareTag("Player") && objectiveisopen == true)
        {
            GO1.SetActive(true);
            GO2.SetActive(false);
        }
        
    }
}
