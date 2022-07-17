using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMODUnity;

public class PlaySoundEffect : MonoBehaviour
{
    [SerializeField] private FMODUnity.StudioEventEmitter eventEmitter;
    public UnityEvent OnSoundEffectPlay;

    public void PlayEvent()
    {
        if (eventEmitter != null) eventEmitter.SendMessage("Play");
    }

}
