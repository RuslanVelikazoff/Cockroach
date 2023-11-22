using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cockroachPrefab;

    private void Awake()
    {
        int amountCockroach = Random.Range(4, 12);

        SpawnCockroach(amountCockroach);
    }

    private void SpawnCockroach(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float x = Random.Range(-6f, 6f);
            float y = Random.Range(-3.6f, 3.6f);

            Vector3 spawnPosition = new Vector3(x, y, 0);

            Instantiate(cockroachPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
