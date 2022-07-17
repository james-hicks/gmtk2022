using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveForce : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 1000;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void PushBack()
    {
        //Apply a force to this Rigidbody in direction of this GameObjects up axis
        m_Rigidbody.AddForce(-transform.forward * m_Thrust, ForceMode.Impulse);
    }
}
