using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private float _forceMultiplier = 1f;
    private float _coolDown = 0.5f;
    private float _cd;
    private Rigidbody _rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _cd <= 0)
        {
            Debug.Log("bounce");
            _rb = other.GetComponent<Rigidbody>();
            if (_forceMultiplier > 1f)
            {
                _rb.AddForce(Vector3.up * 5000*_forceMultiplier);
                _rb.AddForce(Vector3.back * 5000*_forceMultiplier);
            }
            else
            {
                _rb.AddForce(Vector3.up * 5000);
            }
            
            _cd = _coolDown;
            _anim.SetTrigger("Bounce");
        }
    }

    private void Update()
    {
        _cd -= Time.deltaTime;
    }
}
