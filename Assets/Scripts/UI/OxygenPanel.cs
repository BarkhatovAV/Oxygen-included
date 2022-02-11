using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class OxygenPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Rope _rope;
    [SerializeField] private RectTransform _rectTransform;

    private void Start()
    {
        _canvasGroup.alpha = 0;
        _rectTransform.DOScale(0, 0);
    }

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
        _canvasGroup.alpha = 1;
        _rectTransform.DOScale(1, 1);
    }
}
