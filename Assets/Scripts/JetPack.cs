using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class JetPack : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _force;
    [SerializeField] private float _offset;
    [SerializeField] private ParticleSystem[] _reactiveFlames;

    private Rigidbody _rigidbody;
    private float rotationX;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector3(_joystick.Horizontal * _force, _joystick.Vertical * _force, 0));

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            rotationX = Mathf.Atan2(_joystick.Vertical, _joystick.Horizontal) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotationX + _offset);
            ReactiveFlameSetActive();
        }

        Vector3 vec = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = vec;
    }

    private void ReactiveFlameSetActive()
    {
        foreach (ParticleSystem reactiveFlame in _reactiveFlames)
        {
            reactiveFlame.Play();
        }
    }
}
