using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 newGravity;

    private void Start()
    {
        Physics.gravity = newGravity;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
