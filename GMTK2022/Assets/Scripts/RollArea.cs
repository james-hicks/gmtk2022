using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DamageNumbersPro;

public class RollArea : MonoBehaviour
{
    [SerializeField] private float _requiredNumber;
    [SerializeField] private GameObject _newCam;
    [SerializeField] private GameObject _BumpZone;
    public DamageNumber numberDmgPrefab;
    public DamageNumber numberCritPrefab;
    public DamageNumber numberFailPrefab;

    public UnityEvent OnCorrectRoll;

    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    private PlayerMovement _playerMovement;

    private bool _readyToRoll;
    private bool _doOnce = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _readyToRoll = true;
            OnEnter.Invoke();
            other.GetComponent<PlayerMovement>().CanRoll = true;
            _playerMovement = other.GetComponent<PlayerMovement>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            _readyToRoll = false;
            OnExit.Invoke();
            other.GetComponent<PlayerMovement>().CanRoll = false;
        }
    }

    private void Update()
    {
        _newCam.SetActive(_readyToRoll);
        if (!_readyToRoll || _doOnce) return;
        if(_playerMovement.CurrentSide == 1)
        {
            Debug.Log("Critical Fail");
            DamageNumber damageNumber = numberFailPrefab.Spawn(_playerMovement.transform.position);
            StartCoroutine(BumpZone());
        }
        else if (_requiredNumber == 4 && _playerMovement.CurrentSide == 6)
        {
            Debug.Log("Critical Roll!");
            OnCorrectRoll.Invoke();
            DamageNumber damageNumber = numberCritPrefab.Spawn(_playerMovement.transform.position);
            _doOnce = true;

        } else if(_requiredNumber == 6 && _playerMovement.CurrentSide == 8)
        {
            Debug.Log("Critical Roll!");
            OnCorrectRoll.Invoke();
            DamageNumber damageNumber = numberCritPrefab.Spawn(_playerMovement.transform.position);
            _doOnce = true;
        } else if (_requiredNumber == 8 && _playerMovement.CurrentSide == 10)
        {
            Debug.Log("Critical Roll!");
            OnCorrectRoll.Invoke();
            DamageNumber damageNumber = numberCritPrefab.Spawn(_playerMovement.transform.position);
            _doOnce = true;
        } else if(_requiredNumber == 20 && _playerMovement.CurrentSide == 20)
        {
            Debug.Log("Critical Roll!");
            OnCorrectRoll.Invoke();
            DamageNumber damageNumber = numberCritPrefab.Spawn(_playerMovement.transform.position);
            _doOnce = true;
        }
        else if (_playerMovement.CurrentSide >= _requiredNumber)
        {
            _doOnce = true;
            OnCorrectRoll.Invoke();
            Debug.Log("YOU GOT THE RIGHT ROLL! :DDDDDDDDDDDDDDDDDDDDD");
        }
    }

    private IEnumerator BumpZone()
    {
        _BumpZone.SetActive(true);
        yield return new WaitForSeconds(1f);
        _BumpZone.SetActive(false);
    }

}
