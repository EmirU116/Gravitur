using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [Header("Movement")] 
   public float moveSpeed;

   public Transform orientation;
   
   private float horizontalInput;
   private float verticalInput;

   private Vector3 moveDirection;

   private Rigidbody rb;

   public float groundDrag;
   
   [Header("Ground Check")] 
   public float playerHeight;

   public LayerMask whatIsGround;
   private bool grounded;

   [Header("Sound Effect")] 
   public AudioSource src;
   
   private void Start()
   {
      rb = GetComponent<Rigidbody>();
      rb.freezeRotation = true;
   }

   private void Update()
   {
      // ground check
      grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
      
      MyInput();
      SpeedControl();
      
      // handle drag
      if (grounded)
      {
         rb.drag = groundDrag;
      }
      else
      {
         rb.drag = 0;
      }

      if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||Input.GetKey(KeyCode.A))
      {
         src.enabled = true;
      }
      else
      {
         src.enabled = false;
      }
   }

   private void FixedUpdate()
   {
      MovePlayer();
   }

   void MyInput()
   {
      horizontalInput = Input.GetAxisRaw("Horizontal");
      verticalInput = Input.GetAxisRaw("Vertical");
      
   }

   void MovePlayer()
   {
      // calculating movement direction
      moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

      rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
   }

   void SpeedControl()
   {
      Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
      
      // limit velocity if needed
      if (flatVel.magnitude > moveSpeed)
      {
         Vector3 limitVel = flatVel.normalized * moveSpeed;
         rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
      }
   }
}
