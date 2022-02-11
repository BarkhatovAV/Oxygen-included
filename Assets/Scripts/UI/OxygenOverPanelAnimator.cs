using UnityEngine;

[RequireComponent(typeof(Animator))]
public class OxygenOverPanelAnimator : MonoBehaviour
{
    [SerializeField] private Rope _rope;
    [SerializeField] private Oxygen _oxygen;

    private string _isFade = "IsFade";
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _rope.Broken += OnRopeBroken;
        _oxygen.OxygenOver += OnOxygenOver;
    }

    private void OnDisable()
    {
        _rope.Broken -= OnRopeBroken;
        _oxygen.OxygenOver -= OnOxygenOver;
    }

    private void OnRopeBroken()
    {
        _animator.SetBool(_isFade, true);
    }

    private void OnOxygenOver()
    {
        _animator.SetBool(_isFade, false);
    }
}
