using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
#pragma warning disable 649

public class PlayerController : MonoBehaviour
{
    // initial cursor state
    [SerializeField] private CursorLockMode _cursorMode = CursorLockMode.Locked;

    private PlayerMovement _playerMovement;
    private Vector2 _moveInput;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        Cursor.lockState = _cursorMode;
        Physics.IgnoreLayerCollision(9, 7);
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        _playerMovement?.Jump();
    }

    public void OnRollDice(InputValue value)
    {
        _playerMovement?.Roll();
    }

    public void OnPause(InputValue value)
    {
        _playerMovement?.Pause();
    }

    public void Update()
    {
        if (_playerMovement == null) return;

        // find correct right/forward directions based on main camera rotation
        Vector3 up = Vector3.up;
        Vector3 right = Camera.main.transform.right;
        Vector3 forward = Vector3.Cross(right, up);
        Vector3 moveInput = forward * _moveInput.y + right * _moveInput.x;

        // send player input to character movement
        _playerMovement.SetMoveInput(moveInput);
    }
}
