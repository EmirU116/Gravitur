using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScript : MonoBehaviour
{
    public GameObject SKY;
    public Material skyMaterial;


    private void Start()
    {
        SKY.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {

        }
    }
}
