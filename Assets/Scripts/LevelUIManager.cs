using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField]
    private Button menuButton;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private Button nextLevelButton;
    [SerializeField]
    private Button homeButton;

    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private Button continueGameButton;
    [SerializeField]
    private Button exitButton;
    [SerializeField]
    private Text scoreInLoseText;

    [SerializeField]
    private YG.YandexGame sdk;

    private void Awake()
    {
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

    public void LosePanel(int score)
    {
        losePanel.SetActive(true);

        scoreInLoseText.text = "Количество уничтоженных монстров: " + score;

        if (continueGameButton != null)
        {
            continueGameButton.onClick.RemoveAllListeners();
            continueGameButton.onClick.AddListener(() =>
            {
                sdk._RewardedShow(1);
            });
        }

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

    public void ContinueGameCul()
    {
        SceneManager.LoadScene(1);
    }
}
