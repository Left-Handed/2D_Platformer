using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Movement_Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpForce = 4f;
    [SerializeField] private LayerMask _layerMask;

    private PlayerAnimatorController _animation;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private bool _isGround = true;
    private float _axisX;
    private float _radiusCheckGround = 0.01f;

    private void Awake()
    {
        _animation = GetComponent<PlayerAnimatorController>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Roll();
        Jump();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Move()
    {
        _axisX = Input.GetAxis("Horizontal");

        if (_isGround)
        {
            if (Input.GetKey(KeyCode.D))
            {
                _spriteRenderer.flipX = false;
                Roll();
            }

            if (Input.GetKey(KeyCode.A))
            {
                _spriteRenderer.flipX = true;
            }

            if (_axisX != 0)
            {
                if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Roll") == false)
                    _animator.Play("Run");
            }
            else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Roll") == false)
            {
                _axisX = 0;
                _animator.Play("Idle");
            }
        }

        _rigidbody2D.velocity = new Vector2(_axisX * _speed, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGround && _animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") == false)
        {
            _isGround = false;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
                _animator.Play("Jump");
        }
    }

    private void Roll()
    {
        //if (Input.GetButtonDown("Roll") && _isGround && _animator.GetCurrentAnimatorStateInfo(0).IsName("Roll") == false)
        //{
        //    _rigidbody2D.velocity = new Vector2(5, _rigidbody2D.velocity.y);
        //    _animator.Play("Roll");
        //}
    }

    private void CheckGround()
    {
        //if (Physics2D.OverlapCircle(transform.position, _radiusCheckGround, _layerMask) && _rigidbody2D.velocity.y == 0)
        //{
        //    _isGround = true;
        //}
        _isGround = Physics2D.OverlapCircle(transform.position, _radiusCheckGround, _layerMask);
    }
}