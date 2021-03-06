using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Checkpoint[] _checkpoints;
    [SerializeField] private Checkpoint _currentCheckpoint;

    private void Start()
    {
        if(_checkpoints[0] != null) _currentCheckpoint = _checkpoints[0];
    }

    private void Update()
    {
        if(_player.position.y < -20f)
        {
            ResetToCheckpoint();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ResetToCheckpoint();
        }
    }

    public void SetCheckpoint(Checkpoint _checkpoint)
    {
        _currentCheckpoint = _checkpoint;
    }

    public void ResetToCheckpoint()
    {
        _player.position = _currentCheckpoint.Spawn.position;
    }
}
