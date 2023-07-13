using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public Transform playerObject, destination; // player and where the player should spawn
    public BoxCollider self;

    [SerializeField] private int loopCounting; 

    private void Start()
    {
        loopCounting = 0;   // starts the loop from 0 (just in case) 
    }

    private void Update()
    {
        // win state to break the loop 
        if (loopCounting >= 3)
        {
            Debug.Log("You broke the loop");
            self.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerObject.position = destination.position;   // spawns the player to destination position
            loopCounting++; // increment 
        }
    }
}
