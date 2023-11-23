using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Text recordText;

    [SerializeField]
    private Button musicButton;
    [SerializeField]
    private Sprite musicOnSprite;
    [SerializeField]
    private Sprite musicOffSprite;

    [SerializeField]
    private Button soundButton;
    [SerializeField]
    private Sprite soundOnSprite;
    [SerializeField]
    private Sprite soundOffSprite;

    private void Start()
    {
        recordText.text = "Рекорд: " + PlayerPrefs.GetInt("HighScore").ToString();

        SetButtonSprite();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt("Score", 0);
                SceneManager.LoadScene(1);
            });
        }
        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("MusicVolume") == 1f)
                {
                    AudioManager.instance.OffMusic();
                }
                else
                {
                    AudioManager.instance.OnMusic();
                }

                SetButtonSprite();
            });
        }
        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("SoundVolume") == 1f)
                {
                    AudioManager.instance.OffSound();
                }
                else
                {
                    AudioManager.instance.OnSound();
                }

                SetButtonSprite();
            });
        }
    }

    private void SetButtonSprite()
    {
        if (PlayerPrefs.GetFloat("MusicVolume") == 1f)
        {
            musicButton.GetComponent<Image>().sprite = musicOnSprite;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = musicOffSprite;
        }

        if (PlayerPrefs.GetFloat("SoundVolume") == 1f)
        {
            soundButton.GetComponent<Image>().sprite = soundOnSprite;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundOffSprite;
        }
    }
}
