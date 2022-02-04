using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private Camera _camera;
    private Vector3 _vector3;
   
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        _vector3 = new Vector3(_camera.transform.position.x, _target.transform.position.y, _camera.transform.position.z);
        _camera.transform.position = _vector3;
    }


}
