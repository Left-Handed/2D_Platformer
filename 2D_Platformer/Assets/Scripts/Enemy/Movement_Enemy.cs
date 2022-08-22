using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class Movement_Enemy : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private int _currentPoint;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        DisclosePoints();
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        _spriteRenderer.flipX = (transform.position.x - target.position.x > 0);

        _animator.Play(GoblinAnimatorController.States.Run);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void DisclosePoints()
    {
        _points = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
        {
            _points[i] = _point.GetChild(i);
        }
    }
}
