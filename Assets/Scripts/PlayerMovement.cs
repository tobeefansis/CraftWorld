using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    public LayerMask groundMask;

    Transform _transform;
    [Range(0, 2)] public float groudCheckDistance;
    BoxCollider2D _boxCollider2;
    [Range(1, 50)] public float Speed = 2;
    [Range(1, 50)] public float JumpForce = 2;
    public Rigidbody2D RB;
    public KeyCode Jump;
    public KeyCode Left;
    public KeyCode Right;

    private void Start()
    {
        _transform = transform;
        RB = _transform.GetComponent<Rigidbody2D>();
        _boxCollider2 = _transform.GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(Jump))
        {
            RB.AddForce(Vector2.up * JumpForce * 100f);
        }

        var h = Input.GetAxis("Horizontal");
        RB.velocity = new Vector2(Speed * h, RB.velocity.y);

    }

    private bool IsGrounded()
    {
        //return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;

        float extraHeightText = 0.2f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider2.bounds.center, _boxCollider2.bounds.size, 0f, Vector2.down, extraHeightText, groundMask);

        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(_boxCollider2.bounds.center + new Vector3(_boxCollider2.bounds.extents.x, 0), Vector2.down * (_boxCollider2.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(_boxCollider2.bounds.center - new Vector3(_boxCollider2.bounds.extents.x, 0), Vector2.down * (_boxCollider2.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(_boxCollider2.bounds.center - new Vector3(_boxCollider2.bounds.extents.x, _boxCollider2.bounds.extents.y + extraHeightText), Vector2.right * (_boxCollider2.bounds.extents.x * 2f), rayColor);


        return raycastHit.collider != null;
    }
}
