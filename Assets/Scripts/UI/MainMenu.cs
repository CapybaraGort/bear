using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Zenject.Inject] private PauseManager pauseManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject child;

    public void Initialize()
    {
        pauseManager.SetPause(true);
        scoreText.text = "Ваш рекорд: " + SaveableData.Record;
    }

    private void OnEnable()
    {
        playButton.onClick.AddListener(OnPlayClick);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(OnPlayClick);
    }

    private void OnPlayClick()
    {
        pauseManager.SetPause(false);
        child.SetActive(false);
    }
}
