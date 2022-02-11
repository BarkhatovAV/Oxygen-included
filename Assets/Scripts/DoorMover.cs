using DG.Tweening;
using UnityEngine;

public class DoorMover : MonoBehaviour
{
    [SerializeField] private Oxygen _oxygen;
    [SerializeField] private float _target;
    [SerializeField] private float _duration;

    private void OnEnable()
    {
        _oxygen.OxygenOver += OnOxygenIsOver;
    }

    private void OnDisable()
    {
        _oxygen.OxygenOver -= OnOxygenIsOver;
    }

    private void OnOxygenIsOver()
    {
        transform.DOMoveY(_target, _duration);
    }
}
