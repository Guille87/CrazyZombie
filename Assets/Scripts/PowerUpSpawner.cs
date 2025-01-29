using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] Transform[] spawnPoints;

    GameObject powerUp;

    void Start()
    {
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnPowerUp()
    {
        while (true)
        {
            if (powerUp == null)
            {
                yield return new WaitForSeconds(delay);

                Vector3 position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                powerUp = Instantiate(powerUpPrefab, position, Quaternion.identity);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
