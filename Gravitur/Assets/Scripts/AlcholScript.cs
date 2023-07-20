using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Timer = System.Timers.Timer;

public class AlcholScript : MonoBehaviour
{
    [SerializeField] public PostProcessVolume blurr;
    [SerializeField] public float time;
    [SerializeField] public bool canDrink;
    [SerializeField] public bool hasDrank;
    [SerializeField] public GameObject whiskeyGlass;
    

    //when near the drink, it should be able to drink
    public void OnTriggerEnter(Collider other)
    {
        canDrink = true;
    }
    // if not near the drink, player cant drink
    public void OnTriggerExit(Collider other)
    {
        canDrink = false;
    }

    // when running this method, it will make a drunk effect on player for
    // depending on the timer.
    public void AlcoholEffect()
    {
        blurr.enabled = true;
        if (time > 0)
        {
            hasDrank = true;
            Debug.Log(time);
            whiskeyGlass.SetActive(false);
        }
    }
}
