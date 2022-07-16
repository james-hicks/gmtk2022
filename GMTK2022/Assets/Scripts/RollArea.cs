using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollArea : MonoBehaviour
{
    [SerializeField] private float _requiredNumber;
    private PlayerMovement _playerMovement;

    private float _playerNumber;
    private bool _readyToRoll;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _readyToRoll = true;
            other.GetComponent<PlayerMovement>().CanRoll = true;
            _playerMovement = other.GetComponent<PlayerMovement>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            _readyToRoll = false;
            other.GetComponent<PlayerMovement>().CanRoll = false;
        }
    }

    private void Update()
    {
        if (!_readyToRoll) return;
        //_playerMovement
    }

}
