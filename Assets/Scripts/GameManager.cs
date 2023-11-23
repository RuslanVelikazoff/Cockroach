using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cockroachPrefab;
    private List<GameObject> cockroachs;

    [SerializeField]
    private GameObject oggyPrefab;

    [SerializeField]
    private int score;

    private LevelUIManager levelUI;

    private void Awake()
    {
        Time.timeScale = 1;
        levelUI = FindObjectOfType<LevelUIManager>();
        score = PlayerPrefs.GetInt("Score");
        levelUI.SetScoreText(score);

        int amountCockroach = Random.Range(4, 12);
        cockroachs = new List<GameObject>(amountCockroach);

        int amountOggy = Random.Range(1, (int)(amountCockroach / 2));

        SpawnCockroach(amountCockroach);
        SpawnOggy(amountOggy);
    }

    private void SpawnCockroach(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float x = Random.Range(-6f, 6f);
            float y = Random.Range(-3.6f, 3.6f);

            Vector3 spawnPosition = new Vector3(x, y, 0);

            GameObject cockroach = Instantiate(cockroachPrefab, spawnPosition, Quaternion.identity);
            cockroachs.Add(cockroach);
        }
    }

    private void SpawnOggy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-3f, 3f);

            Vector3 spawnPosition = new Vector3(x, y, 0);

            Instantiate(oggyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void WinGame()
    {
        if (cockroachs.Count <= 0)
        {
            levelUI.WinPanel();
            AudioManager.instance.Play("Win");
            Debug.Log("You Win!");
        }
    }

    private void LoseGame()
    {
        AudioManager.instance.Play("Lose");
        levelUI.LosePanel(score);
    }

    private void AddScore()
    {
        score += 1;
        PlayerPrefs.SetInt("Score", score);

        levelUI.SetScoreText(score);

        if (score >= PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void KillCockroach(GameObject cockroach)
    {
        AudioManager.instance.Play("Kill");
        AddScore();
        Destroy(cockroach);
        cockroachs.Remove(cockroach);
        WinGame();
    }

    public void KillOggy(GameObject oggy)
    {
        Time.timeScale = 0;
        Destroy(oggy);
        LoseGame();
        Debug.Log("You Lose!");
    }
}
