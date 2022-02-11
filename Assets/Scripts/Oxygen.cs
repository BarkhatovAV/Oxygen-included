using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Oxygen : MonoBehaviour
{
    [SerializeField] private Rope _rope;
    [SerializeField] private float _duration;
    [SerializeField] private EntranceZone _entranceZone;

    private float _normalizedOxygenCount;
    private float _currentTime;
    private bool _isUseOxygen = true;

    public event UnityAction<float> OxygenCountChanged;
    public event UnityAction OxygenOver;

    private void OnEnable()
    {
        _rope.Broken += OnRopeBroken;
        _entranceZone.PlayerGoInEnteranceZone += OnPlayerGoInEnteranceZone;
    }

    private void OnDisable()
    {
        _rope.Broken -= OnRopeBroken;
        _entranceZone.PlayerGoInEnteranceZone -= OnPlayerGoInEnteranceZone;
    }

    private void OnRopeBroken()
    {
        StartCoroutine(UseOxygen());
    }

    private void OnPlayerGoInEnteranceZone()
    {
        _isUseOxygen = false;
    }

    private IEnumerator UseOxygen()
    {
        while (_currentTime < _duration && _isUseOxygen)
        {
            _currentTime += Time.deltaTime;
            _normalizedOxygenCount = 1 - _currentTime / _duration;
            OxygenCountChanged?.Invoke(_normalizedOxygenCount);

            if (_normalizedOxygenCount <= 0)
            {
                OxygenOver?.Invoke();
            }
            yield return null;
        }
    }
}
