using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSides : MonoBehaviour
{
    public int Side;
    public bool OnGround;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SideCheck")
        {
            OnGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "SideCheck")
        {
            OnGround = false;
        }
    }
}

