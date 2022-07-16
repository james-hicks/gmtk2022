using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    private float _coolDown = 0.5f;
    private float _cd;
    private Rigidbody _rb;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && _cd <= 0)
        {
            Debug.Log("bounce");
            _rb = other.GetComponent<Rigidbody>();
            _rb.AddForce(Vector3.up * 5000);
            _cd = _coolDown;
        }
    }

    private void Update()
    {
        _cd -= Time.deltaTime;
    }
}
