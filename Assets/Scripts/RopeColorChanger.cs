using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeColorChanger : MonoBehaviour
{
    [SerializeField] private Rope _rope;
    [SerializeField] private Material _material;
    [SerializeField] private Color _endColor;
    
    private float _duration;
    private Color _startColor;
    private float _currentTime;
    private float _normalizedCurrentTime;

    private void OnEnable()
    {
        _rope.StartBreaking += OnColorChanged;
    }

    private void OnDisable()
    {
        _rope.StartBreaking -= OnColorChanged;
    }

    private void Start()
    {
        _startColor = _material.color;
    }

    private void OnColorChanged(float duration)
    {
        _currentTime = 0;
        _duration = duration;
        StartCoroutine(ColorChange());
    }

    private IEnumerator ColorChange()
    {
        while(_duration > _currentTime)
        {
            _currentTime += Time.deltaTime;
            _normalizedCurrentTime = _currentTime / _duration;
            _material.color = Color.Lerp(_startColor, _endColor, _normalizedCurrentTime);
             yield return null;
        }
        _material.color = _startColor;
    }
}
