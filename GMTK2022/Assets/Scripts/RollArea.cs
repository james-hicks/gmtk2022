using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RollArea : MonoBehaviour
{
    [SerializeField] private float _requiredNumber;

    public UnityEvent OnCorrectRoll;

    private PlayerMovement _playerMovement;

    private bool _readyToRoll;
    private bool _doOnce = false;

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
        if (!_readyToRoll || _doOnce) return;
        if(_playerMovement.CurrentSide == _requiredNumber)
        {
            _doOnce = true;
            OnCorrectRoll.Invoke();
            Debug.Log("YOU GOT THE RIGHT ROLL! :DDDDDDDDDDDDDDDDDDDDD");
        }
    }

}
