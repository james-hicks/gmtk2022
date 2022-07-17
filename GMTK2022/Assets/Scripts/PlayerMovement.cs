using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using FMODUnity;
using DamageNumbersPro;
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
    public int CurrentSide = -1;
    public bool CanRoll { get; set; }

    [Header("Audio")]
    [SerializeField] private FMODUnity.StudioEventEmitter eventEmitter;

    [Header("UI")]
    [SerializeField] private Animator _pauseMenu;

    [Header("Damage Number")]
    public DamageNumber numberDmgPrefab;

    private Rigidbody _rb;
    private Vector3 _moveInput;
    public bool _grounded;
    private bool _hasControl = true;

    private bool _canJump = true;
    private float _jumpCD;

    private float _moveSpeedMultiplier;

    public bool _gameIsPaused = false;

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
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            if (eventEmitter != null) eventEmitter.SendMessage("Play");
        }
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
        _rb.AddForce(Vector3.up * Random.Range(6500f, 7000f));
        _rb.AddTorque(Vector3.forward * Random.Range(1750f, 2600f));
        _rb.AddTorque(Vector3.right * Random.Range(1750f, 2600f));
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
        while(!_grounded)
        {
            yield return null;
        }
        while(_rb.velocity.magnitude > 0.3f)
        {
            yield return null;
        }

        for (int i = 0; i < _sides.Length; i++)
        {
            if (_sides[i].OnGround)
            {
                Debug.Log(_sides[i].Side + " On Ground");
                CurrentSide = _sides[i].Side;
                DamageNumber damageNumber = numberDmgPrefab.Spawn(transform.position, CurrentSide);
                StartCoroutine(ResetNumber());
                break;
            }
        }

        _hasControl = true;
    }

    public void SetCanMove(bool a)
    {
        _hasControl = a;
    }

    public void Pause()
    {

        if (_gameIsPaused)
        {
            Debug.Log("Unpause");
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            if(_pauseMenu != null) _pauseMenu.SetTrigger("Pause");
            _gameIsPaused = false;
        }
        if (!_gameIsPaused)
        {
            Debug.Log("Pause");
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            if (_pauseMenu != null) _pauseMenu.SetTrigger("Pause");
            _gameIsPaused = true;
        }
    }

    public void UnPause()
    {
        if (_gameIsPaused)
        {
            Debug.Log("Unpause");
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            if (_pauseMenu != null) _pauseMenu.SetTrigger("Pause");
            _gameIsPaused = false;
        }
    }

    private IEnumerator ResetNumber()
    {
        yield return new WaitForSeconds(1f);
        CurrentSide = -1;
    }
}
