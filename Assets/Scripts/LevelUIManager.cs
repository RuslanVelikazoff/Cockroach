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
    private Text scoreText;

    [SerializeField]
    private Sprite[] backgroundSprites;

    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private Button nextLevelButton;
    [SerializeField]
    private Button homeButton;

    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private Button exitButton;
    [SerializeField]
    private Text scoreInLoseText;

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

    public void LosePanel(int score)
    {
        losePanel.SetActive(true);

        scoreInLoseText.text = "Количество пойманных тараканов: " + score;

        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
            });
        }
    }

    public void WinPanel()
    {
        winPanel.SetActive(true);

        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.RemoveAllListeners();
            nextLevelButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(1);
            });
        }
        if (homeButton != null)
        {
            homeButton.onClick.RemoveAllListeners();
            homeButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
            });
        }
    }

    public void SetScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}
