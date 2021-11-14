using System;
using __Game.__Scripts.Interfaces;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour, ICar
{
    [SerializeField] private float moveSpeed;

    public float MoveSpeed => moveSpeed;
    
    private Vector3 _acceleration;
    private Joystick _joystick;
    
    private void Awake()
    {
        _joystick = FindObjectOfType<Joystick>();
    }

    private void Update()
    {
        
        if (Mathf.Abs(_joystick.Horizontal) > 0.2f || Mathf.Abs(_joystick.Vertical) > 0.2f)
        {
            _acceleration.x = _joystick.Horizontal;
            _acceleration.z = _joystick.Vertical;
        }
        else
        {
            _acceleration = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if (_acceleration != Vector3.zero)
        {
            Turn();
        }
        
        Move();
    }

    public void Move()
    {
        transform.Translate(_acceleration * moveSpeed * Time.deltaTime, Space.World);
    }

    public void Turn()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_acceleration), 10 * Time.deltaTime);
    }

}
