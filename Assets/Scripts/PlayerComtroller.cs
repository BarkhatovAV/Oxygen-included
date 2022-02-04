using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerComtroller : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _offset;

    private float rotationX;
    public event UnityAction JoystickActived;
    private void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector3(_joystick.Horizontal * _moveSpeed, _joystick.Vertical * _moveSpeed, 0));

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            rotationX = Mathf.Atan2(_joystick.Vertical, _joystick.Horizontal) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotationX + _offset);
        }

        Vector3 vec = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = vec;
    }
}
