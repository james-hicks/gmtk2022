using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform _spawnTransform;


    public Transform Spawn => _spawnTransform;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<CheckpointHandler>().SetCheckpoint(this);
        }
    }
}
