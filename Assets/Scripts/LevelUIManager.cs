using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField]
    private Button menuButton;

    [SerializeField]
    private Image backgroundImage;

    [SerializeField]
    private Sprite[] backgroundSprites;

    private void Awake()
    {
        SetRandomIndex();
        SetBackground();

        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (menuButton != null)
        {
            menuButton.onClick.RemoveAllListeners();
            menuButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
            });
        }
    }

    private void SetBackground()
    {
        backgroundImage.sprite = backgroundSprites[PlayerPrefs.GetInt("RandomIndex")];
    }

    private void SetRandomIndex()
    {
        int randomIndex = Random.Range(0, backgroundSprites.Length - 1);

        if (!PlayerPrefs.HasKey("RandomIndex"))
        {
            PlayerPrefs.SetInt("RandomIndex", randomIndex);
            return;
        }

        if (PlayerPrefs.GetInt("RandomIndex") == randomIndex)
        {
            SetRandomIndex();
        }

        else
        {
            PlayerPrefs.SetInt("RandomIndex", randomIndex);
        }

    }
}
