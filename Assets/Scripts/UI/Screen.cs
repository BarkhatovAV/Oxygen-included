using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Screen : MonoBehaviour
{
    [SerializeField] private Button _button;

    private string _sceneName = "SampleScene";

    private void OnEnable()
    {
        _button.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(_sceneName);
    }

    private void OnGameOver()
    {
        Open();
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }
}
