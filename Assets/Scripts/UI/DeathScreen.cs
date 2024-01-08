using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [Zenject.Inject] private Player player;
    [Zenject.Inject] private PauseManager pauseManager;
    [SerializeField] private GameObject child;
    [SerializeField] private Button retryButton;
    [SerializeField] private TextMeshProUGUI score;

    private void OnEnable()
    {
        player.OnPlayerDeath += OnPlayerDeath;
        retryButton.onClick.AddListener(OnClickRetry);
    }

    private void OnDisable()
    {
        player.OnPlayerDeath -= OnPlayerDeath;
        retryButton.onClick.RemoveListener(OnClickRetry);
    }

    private void OnClickRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnPlayerDeath()
    {
        child.SetActive(true);
        pauseManager.SetPause(true);
        score.text = "Ваш рекорд: " + SaveableData.Record;
    }
}
