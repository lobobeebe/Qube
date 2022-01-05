using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField]
    private LayerMask _GroundLayers;

    public bool IsGrounded
    {
        get;
        private set;
    }

    private bool IsGroundLayer(int layer)
    {
        return (_GroundLayers == (_GroundLayers | 1 << layer));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGroundLayer(collision.otherCollider.gameObject.layer))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (IsGroundLayer(collision.otherCollider.gameObject.layer))
        {
            IsGrounded = false;
        }
    }
}
