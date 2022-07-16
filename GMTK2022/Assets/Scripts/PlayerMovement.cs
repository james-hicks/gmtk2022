using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
#pragma warning disable 649
#pragma warning disable 414

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    private Rigidbody rb;
    private Vector3 MoveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        rb.AddForce(MoveInput * moveSpeed);
    }

    public void SetMoveInput(Vector3 moveInput)
    {
        MoveInput = moveInput;
    }

    public void Jump()
    {
        Debug.Log("Jump");
    }

    public void Roll()
    {
        Debug.Log("Roll");
    }
}
