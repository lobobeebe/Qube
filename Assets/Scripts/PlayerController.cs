using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _Speed;

    [SerializeField]
    private float _JumpForce;

    [SerializeField]
    private float _GroundCheckerRadius;

    [SerializeField]
    private Vector2 _GroundCheckerOffset;

    [SerializeField]
    private LayerMask _GroundLayerMask;

    [SerializeField]
    private float fallMultiplier;

    [SerializeField]
    private float lowJumpMultiplier;

    private bool _IsGrounded;

    private Rigidbody2D _Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * _Speed;
        _Rigidbody.velocity = new Vector2(moveBy, _Rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _IsGrounded)
        { 
            _Rigidbody.velocity = new Vector2(_Rigidbody.velocity.x, _JumpForce);
        }
    }

    void BetterJump()
    {
        if (_Rigidbody.velocity.y < 0)
        {
            _Rigidbody.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_Rigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            _Rigidbody.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle((Vector2)transform.position + _GroundCheckerOffset, _GroundCheckerRadius, _GroundLayerMask);

       _IsGrounded = (collider != null);
    }
}
