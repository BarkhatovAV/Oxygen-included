using UnityEngine;
public class Game : MonoBehaviour
{
    [SerializeField] private EntranceZone _entranceZone;
    [SerializeField] private Oxygen _oxygen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private WinScreen _winScreen;
    [SerializeField] private Joystick _joystick;

    private void OnEnable()
    {
        _entranceZone.PlayerGoInEnteranceZone += OnPlayerGoInEnteranceZone;
        _oxygen.OxygenOver += OnOxygenOver;
    }

    private void OnDisable()
    {
        _entranceZone.PlayerGoInEnteranceZone -= OnPlayerGoInEnteranceZone;
        _oxygen.OxygenOver -= OnOxygenOver;
    }

    private void OnPlayerGoInEnteranceZone()
    {
        _winScreen.Open();
        _joystick.gameObject.SetActive(false);
    }

    private void OnOxygenOver()
    {
        _gameOverScreen.Open();
        _joystick.gameObject.SetActive(false);
    }
}
