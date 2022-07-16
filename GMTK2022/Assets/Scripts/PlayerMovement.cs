using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
#pragma warning disable 649
#pragma warning disable 414

public class PlayerMovement : MonoBehaviour
{
    [Header("Roll")]
    [SerializeField] private float moveSpeed = 10f;

    [Header("Jump")]
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private float _jumpForce = 10f;

    [Header("Dice")]
    [SerializeField] private DiceSides[] _sides;
    public bool CurrentSide { get; private set; }
    public bool CanRoll { get; set; }


    private Rigidbody _rb;
    private Vector3 _moveInput;
    public bool _grounded;
    private bool _hasControl = true;

    private bool _canJump = true;
    private float _jumpCD;

    private float _moveSpeedMultiplier;

    private void Awake()
    {
        Physics.IgnoreLayerCollision(7, 9);
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        _grounded = CheckGrounded();
    }


    private void Move()
    {
        if (!_hasControl) return;
        if (!_grounded)
        {
            _moveSpeedMultiplier = 0.3f;
        }
        else
        {
            _moveSpeedMultiplier = 1f;
        }

        _rb.AddForce(_moveInput * moveSpeed * _moveSpeedMultiplier);
    }

    public void SetMoveInput(Vector3 moveInput)
    {
        _moveInput = moveInput;
    }

    public void Jump()
    {
        /*if (CheckGrounded() && _canJump)
        {
            Debug.Log("Jump");
            _rb.AddForce(Vector3.up * _jumpForce * 1000);
            StartCoroutine(CoolDown(_jumpCD, _canJump));
        }*/
        
    }

    public void Roll()
    {
        if (!CanRoll) return;
        Debug.Log("Roll");
        _hasControl = false;
        _rb.AddForce(Vector3.up * 7000);
        StartCoroutine(Rolling());
    }

    private bool CheckGrounded()
    {
        if (_groundCheck.Grounded) return true;

        return false;

    }

    private IEnumerator CoolDown(float coolDown, bool Skill)
    {
        Skill = false;
        float cd = coolDown;
        while(cd >= 0f)
        {
            cd -= Time.deltaTime;
            yield return null;
        }
        Skill = true;
        yield return null;
    }

    private IEnumerator Rolling()
    {
        yield return new WaitForSeconds(0.3f);
        while(_rb.velocity.magnitude > 0.5)
        {
            //Debug.Log("Rolling");
            yield return null;
        }

        foreach (var side in _sides)
        {
            if (side.OnGround)
            {
                Debug.Log(side.Side + " On Ground");
                break;
            }
            else
            {
                Debug.Log(side.Side + "Not On Ground");
            }

        }
        _hasControl = true;
        Debug.Log("RolledxD");
    }
}
