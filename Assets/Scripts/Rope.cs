using Obi;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ObiRope))]
[RequireComponent(typeof(ObiPathSmoother))]
public class Rope : MonoBehaviour
{
    [SerializeField] private int _maxObiPathSmoother;
    [SerializeField] private float _duration;

    private ObiRope _rope;
    private ObiPathSmoother _obiPathSmoother;
    private int _numberBreakingElement = 90;
    private bool _isBroken = false;

    public event UnityAction<float> StartBreaking;
    public event UnityAction Broken;

    private void Start()
    {
        _rope = GetComponent<ObiRope>();
        _obiPathSmoother = GetComponent<ObiPathSmoother>();
    }

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
        _rope.Tear(_rope.elements[_numberBreakingElement]);
        _rope.RebuildConstraintsFromElements();
        Broken?.Invoke();
    }
}
