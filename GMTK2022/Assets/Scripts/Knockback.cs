using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 moveDirection;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Hammer Hit");
            _rb = other.GetComponent<Rigidbody>();
            moveDirection = _rb.transform.position - this.transform.position;
            _rb.AddForce(moveDirection.normalized * 10000f);
        }
    }
}
