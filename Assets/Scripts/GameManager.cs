using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject joiPrefab;
    private List<GameObject> joiList;

    [SerializeField]
    private GameObject markiPrefab;
    private List<GameObject> markiList;

    [SerializeField]
    private GameObject didiPrefab;
    private List<GameObject> didiList;

    [SerializeField]
    private GameObject bobPrefab;
    private List<GameObject> bobList;

    [SerializeField]
    private int score;

    private LevelUIManager levelUI;

    private void Awake()
    {
        Time.timeScale = 1;
        player = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);

        levelUI = FindObjectOfType<LevelUIManager>();
        score = PlayerPrefs.GetInt("Score");
        levelUI.SetScoreText(score);

        int amountJoiPrefab = Random.Range(2, 10);
        joiList = new List<GameObject>(amountJoiPrefab);
        SpawnObstacles(amountJoiPrefab, joiPrefab, joiList);

        int amountMarkiPrefab = Random.Range(2, 10);
        markiList = new List<GameObject>(amountMarkiPrefab);
        SpawnObstacles(amountMarkiPrefab, markiPrefab, markiList);

        int amountDidiPrefab = Random.Range(2, 10);
        didiList = new List<GameObject>(amountDidiPrefab);
        SpawnObstacles(amountDidiPrefab, didiPrefab, didiList);

        int amountBobPrefab = Random.Range(1, 5);
        bobList = new List<GameObject>(amountBobPrefab);
        SpawnObstacles(amountBobPrefab, bobPrefab, bobList);
    }

    private void SpawnObstacles(int amount, GameObject prefab, List<GameObject> list)
    {
        for (int i = 0; i < amount; i++)
        {
            float x = Random.Range(-6f, 6f);
            float y = Random.Range(-3.6f, 3.6f);

            Vector3 spawnPosition = new Vector3(x, y, 0);

            GameObject obstacle = Instantiate(prefab, spawnPosition, Quaternion.identity);
            list.Add(obstacle);
        }
    }

    private void WinGame()
    {
        if (joiList.Count <= 0 && markiList.Count <= 0 && didiList.Count <= 0)
        {
            Destroy(player);
            levelUI.WinPanel();
            AudioManager.instance.Play("Win");
            Debug.Log("You Win!");
        }
    }

    private void LoseGame()
    {
        AudioManager.instance.Play("Lose");
        Destroy(player);
        levelUI.LosePanel(score);
    }

    private void AddScore(int addedScores)
    {
        score += addedScores;
        PlayerPrefs.SetInt("Score", score);

        levelUI.SetScoreText(score);

        if (score >= PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void KillCockroach(GameObject cockroach, string tag)
    {
        AudioManager.instance.Play("Kill");

        if (tag == "DiDi")
        {
            AddScore(2);
            didiList.Remove(cockroach);
        }
        if (tag == "Marki")
        {
            AddScore(1);
            markiList.Remove(cockroach);
        }
        if (tag == "Joi")
        {
            AddScore(3);
            joiList.Remove(cockroach);
        }

        Destroy(cockroach);
        WinGame();
    }

    public void KillBob(GameObject bob)
    {
        Time.timeScale = 0;
        Destroy(bob);
        LoseGame();
        Debug.Log("You Lose!");
    }
}
