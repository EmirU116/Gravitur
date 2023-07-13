using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public Transform playerObject, destination;
    public BoxCollider self;

    [SerializeField] private int loopCounting;

    private void Start()
    {
        loopCounting = 0;
    }

    private void Update()
    {
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
            playerObject.position = destination.position;
            loopCounting++;
        }
    }
}
