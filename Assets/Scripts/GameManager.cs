using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;
    private List<GameObject> obstacles;

    [SerializeField]
    private GameObject allyPrefab;

    [SerializeField]
    private int score;

    private LevelUIManager levelUI;

    private void Awake()
    {
        Time.timeScale = 1;
        levelUI = FindObjectOfType<LevelUIManager>();
        score = PlayerPrefs.GetInt("Score");
        levelUI.SetScoreText(score);

        int amountObstacle = Random.Range(4, 12);
        obstacles = new List<GameObject>(amountObstacle);

        int amountAlly = Random.Range(1, (int)(amountObstacle / 2));

        SpawnObstacle(amountObstacle);
        SpawnAlly(amountAlly);
    }

    private void SpawnObstacle(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float x = Random.Range(-6f, 6f);
            float y = Random.Range(-3.6f, 3.6f);

            Vector3 spawnPosition = new Vector3(x, y, 0);

            GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            obstacles.Add(obstacle);
        }
    }

    private void SpawnAlly(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-3f, 3f);

            Vector3 spawnPosition = new Vector3(x, y, 0);

            Instantiate(allyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void WinGame()
    {
        if (obstacles.Count <= 0)
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

    public void KillObstacle(GameObject obstacle)
    {
        AudioManager.instance.Play("Kill");
        AddScore();
        Destroy(obstacle);
        obstacles.Remove(obstacle);
        WinGame();
    }

    public void KillAlly(GameObject ally)
    {
        Time.timeScale = 0;
        Destroy(ally);
        LoseGame();
        Debug.Log("You Lose!");
    }
}
