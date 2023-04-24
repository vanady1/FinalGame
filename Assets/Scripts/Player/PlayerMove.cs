using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rigidbody;
    private Vector2 _moveDirection;
    private Vector2 _mousePosition;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        AimTowardsMouse();
        MovePlayer();
    }

    private void MovePlayer()
    {
        _rigidbody.velocity = Vector2.ClampMagnitude(_moveDirection * _moveSpeed, _moveSpeed);
    }

    private void AimTowardsMouse()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = _mousePosition - new Vector2(transform.position.x, transform.position.y);
    }
}
