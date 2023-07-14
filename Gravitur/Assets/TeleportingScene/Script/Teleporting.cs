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

            // Calculate the direction from player to destination
            Vector3 direction = destination.position - playerObject.position;

            // Teleport the player to the destination position
            playerObject.position = destination.position;

            // Make the player look towards the destination
            playerObject.LookAt(playerObject.position + direction);

            loopCounting++;
        }
    }
}
