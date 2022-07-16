using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeDie : MonoBehaviour
{
    [SerializeField] private GameObject _currentDice;
    [SerializeField] private GameObject _newDice;

    [SerializeField] private CinemachineFreeLook _playerCam;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            this.gameObject.SetActive(false);
            _newDice.transform.position = _currentDice.transform.position;
            _playerCam.LookAt = _newDice.transform;
            _playerCam.Follow = _newDice.transform;
            _currentDice.SetActive(false);
            _newDice.SetActive(true);
        }
    }
}
