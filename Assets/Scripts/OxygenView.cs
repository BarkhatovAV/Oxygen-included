using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenView : MonoBehaviour
{
    [SerializeField] private Oxygen _oxygen;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _oxygen.OxygenCountChanged += OnOxygenCountChanged;
    }

    private void OnDisable()
    {
        _oxygen.OxygenCountChanged -= OnOxygenCountChanged;
    }
    private void OnOxygenCountChanged(float oxygenCount)
    {
        _slider.value = oxygenCount;
    }
}
