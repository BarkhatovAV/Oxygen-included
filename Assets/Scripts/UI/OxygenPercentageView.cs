using UnityEngine;
using TMPro;

public class OxygenPercentageView : MonoBehaviour
{
    [SerializeField] private Oxygen _oxygen;
    [SerializeField] private TMP_Text _text;

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
        _text.text = "%" + Mathf.RoundToInt(oxygenCount*100);
    }
}
