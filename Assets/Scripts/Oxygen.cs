using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Oxygen : MonoBehaviour
{
    [SerializeField] private Rope _rope;
    [SerializeField] private float _duration;

    private float _normalizedOxygenCount;
    private float _currentTime;
    public event UnityAction<float> OxygenCountChanged;

    private void OnEnable()
    {
        _rope.Broken += OnRopeBroken;
    }

    private void OnDisable()
    {
        _rope.Broken -= OnRopeBroken;
    }

    private void OnRopeBroken()
    {
        StartCoroutine(UseOxygen());
    }

    private IEnumerator UseOxygen()
    {
        while (_currentTime < _duration)
        {
            _currentTime += Time.deltaTime;
            _normalizedOxygenCount = 1 - _currentTime / _duration;
            OxygenCountChanged?.Invoke(_normalizedOxygenCount);
            yield return null;
        }
    }
}
