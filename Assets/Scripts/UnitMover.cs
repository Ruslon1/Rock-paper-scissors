using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class UnitMover : MonoBehaviour, IMover
{
    private Vector2 _currentDirection;
    private float _speed = 2f;
    private Rigidbody2D _rigidbody;
    private Camera _camera;
    private Vector2 _targetPosition;
    private bool _canMove;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        //Move();
    }

    public void MoveRandomDirection()
    {
        SetRandomDirection();
        _targetPosition = GetTargetPosition();
        Move();
    }

    public void MoveOpposite()
    {
        _currentDirection *= -1;
        _targetPosition = GetTargetPosition();
        Move();
    }

    private void Move()
    {
        transform.DOMove(_targetPosition, 5).onComplete = MoveOpposite;
    }

    private void SetRandomDirection()
    {
        _currentDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    private Vector2 GetTargetPosition()
    {
        Ray ray = new Ray(transform.position, _currentDirection * 100);
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

        float minDistance = Mathf.Infinity;

        for (int i = 0; i < 4; i++)
        {
            if (planes[i].Raycast(ray, out float distance))
            {
                if (distance < minDistance)
                {
                    minDistance = distance;
                    var planeIndex = i;
                }
            }
        }
        
        return ray.GetPoint(minDistance);
    }
}