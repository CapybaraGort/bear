using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class MainMenu : MonoBehaviour
{
    [Zenject.Inject] private PauseManager pauseManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject child;

    public void Initialize()
    {
        pauseManager.SetPause(true);
    
        if(YandexGame.SDKEnabled)
        {
            SetRecordText();
        }
    }

    private void OnEnable()
    {
        playButton.onClick.AddListener(OnPlayClick);
        YandexGame.GetDataEvent += SetRecordText;
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(OnPlayClick);
        YandexGame.GetDataEvent -= SetRecordText;
    }
    private void SetRecordText()
    {
        scoreText.text = "Ваш рекорд: " + YandexGame.savesData.Record;
    }

    private void OnPlayClick()
    {
        pauseManager.SetPause(false);
        child.SetActive(false);
    }
}
