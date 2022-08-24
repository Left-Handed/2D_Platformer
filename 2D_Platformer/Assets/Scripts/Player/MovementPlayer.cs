using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class MovementPlayer : MonoBehaviour
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
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _isGround = CheckGround();
        HandlJump();
        HandlMove();
        AnimatorPlay();
    }

    private void HandlMove()
    {
        _axisX = Input.GetAxis("Horizontal");

        _rigidbody2D.velocity = new Vector2(_axisX * _speed, _rigidbody2D.velocity.y);
    }

    private void HandlJump()
    {
        if (Input.GetButtonDown("Jump") && _isGround)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            _isGround = false;
        }
    }

    private bool CheckGround()
    {
        return Physics2D.OverlapCircle(transform.position, _radiusCheckGround, _layerMask) && _rigidbody2D.velocity.y == 0;
    }

    private void AnimatorPlay()
    {
        _animator.SetBool(PlayerAnimatorController.Params.Is_Ground, _isGround);

        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
        }

        if (_isGround)
        {
            if (_axisX != 0)
            {
                _animator.Play(PlayerAnimatorController.States.Run);
            }
            else
            {
                _axisX = 0;
                _animator.Play(PlayerAnimatorController.States.Idle);
            }
        }

    }
            
}