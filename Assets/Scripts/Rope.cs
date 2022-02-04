using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Rope : MonoBehaviour
{
    [SerializeField] ObiRope _rope;
    [SerializeField] ObiPathSmoother _obiPathSmoother;
    [SerializeField] int _maxObiPathSmoother;
    [SerializeField] private float _duration;

    private bool _isBroken = false;
    public event UnityAction<float> StartBreaking;
    public event UnityAction Broken;

    private void FixedUpdate()
    {
        if  (_isBroken == false)
        {
            if (_obiPathSmoother.SmoothLength > _maxObiPathSmoother)
            {
                StartCoroutine(BreakeRope());
                _isBroken = true;
                StartBreaking?.Invoke(_duration);
            }
        } 
    }

    private IEnumerator BreakeRope()
    {
        yield return new WaitForSeconds(_duration);
        _rope.Tear(_rope.elements[70]);//Random.Range(0, _rope.elements.Count)]);
        _rope.RebuildConstraintsFromElements();
        Broken?.Invoke();
    }
}
