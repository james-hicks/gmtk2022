using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool CheckGrounded(Vector3 GroundCheckStart, float GroundCheckOffset, float GroundCheckDistance, float MaxSlopeAngle, LayerMask GroundMask, Vector3 GroundNormal, Vector3 SurfaceVelocity)
    {
        bool hit = Physics.Raycast(GroundCheckStart, -transform.up, out RaycastHit hitInfo, GroundCheckDistance, GroundMask);

        GroundNormal = Vector3.up;
        SurfaceVelocity = Vector3.zero;

        if (!hit) return false;

        if (hitInfo.rigidbody != null) SurfaceVelocity = hitInfo.rigidbody.velocity;

        bool angleValid = Vector3.Angle(transform.up, hitInfo.normal) < MaxSlopeAngle;
        if (angleValid)
        {
            GroundNormal = hitInfo.normal;
            return true;
        }

        return false;
    }
}
