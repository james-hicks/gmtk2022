using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private PlayerMovement _pm;
    [SerializeField] private GameObject _newCam;
    [SerializeField] private float _lookTime = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _pm = other.GetComponent<PlayerMovement>();
            _newCam.SetActive(true);
            _pm.SetCanMove(false);
            StartCoroutine(CameraLook());
        }
    }

    private IEnumerator CameraLook()
    {
        yield return new WaitForSeconds(_lookTime);
        _pm.SetCanMove(true);
        _newCam.SetActive(false);
    }
}
