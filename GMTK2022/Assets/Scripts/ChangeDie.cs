using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FMODUnity;

public class ChangeDie : MonoBehaviour
{
    [SerializeField] private GameObject _currentDice;
    [SerializeField] private GameObject _newDice;
    [SerializeField] private FMODUnity.StudioEventEmitter eventEmitter;

    [SerializeField] private CinemachineFreeLook _playerCam;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (eventEmitter != null) eventEmitter.SendMessage("Play");
            this.gameObject.SetActive(false);
            _newDice.transform.position = _currentDice.transform.position;
            _playerCam.LookAt = _newDice.transform;
            _playerCam.Follow = _newDice.transform;
            _currentDice.SetActive(false);
            _newDice.SetActive(true);
        }
    }
}
