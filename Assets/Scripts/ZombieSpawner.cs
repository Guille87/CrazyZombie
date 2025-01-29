using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay;
    [SerializeField] float zombieMax;
    [SerializeField] GameObject zombiePrefab;

    int numZombies;

    void Start()
    {
        StartCoroutine(SpawnZombie());
    }

    IEnumerator SpawnZombie()
    {
        yield return new WaitForSeconds(spawnDelay * 2);

        while (numZombies < zombieMax)
        {
            Instantiate(zombiePrefab, transform.position, Quaternion.identity);
            numZombies++;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
