using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDie : MonoBehaviour
{
    [SerializeField] private GameObject _currentDice;
    [SerializeField] private GameObject _newDice;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "")
        {

        }
    }
}
