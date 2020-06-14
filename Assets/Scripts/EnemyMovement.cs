using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameManager _gameManager;
    PlayerSettings _playerSettings;
    Transform _transform;
    [Range(0, 30)] public float speed;
    Collider2D _boxCollider2;
    public LayerMask groundMask;

    void Start()
    {
        _gameManager = GameManager.GetFromScene();
        _playerSettings = _gameManager.settings;
        _transform = transform;

        _boxCollider2 = _transform.GetComponent<Collider2D>();
    }


    private void LateUpdate()
    {
        if (IsGrounded())
        {
            Transform min = null;
            foreach (var item in _gameManager.EnemyTargetList)
            {
                if (min == null || Vector2.Distance(_transform.position, item.transform.position) < Vector2.Distance(_transform.position, min.position))
                {
                    min = item.transform;
                }
            }

            if (min.position.x > _transform.position.x)
            {
                transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
            }
            if (min.position.x < _transform.position.x)
            {
                transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);

            }
        }

    }
    private bool IsGrounded()
    {
        float extraHeightText = 0.3f;
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
