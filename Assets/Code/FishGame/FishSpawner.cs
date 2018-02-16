using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    public Fish[] fishes;
    public GameObject fishPrefab;

    [Header("Spawning")] public float spawnChance = 500;
    [Range(0, 5)] public float spawnDelay = 0.25f;

    private bool canSpawn = true;

    private void FixedUpdate()
    {
        Debug.Log(canSpawn);
        if (canSpawn && RandomizerFloat(1, 500) < 5)
        {
            StartCoroutine(SpawnDelay());
            GameObject spawnedFish = Instantiate(fishPrefab, transform, true);
            //spawnedFish.GetComponent<EnemyFish>().properties = fishes[RandomizerInt(0, fishes.Length)];
            spawnedFish.GetComponent<EnemyFish>().properties = fishes[0];
            spawnedFish.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * 500);
        }
    }

    float RandomizerFloat(float min = 1, float max = 1000)
    {
        return Random.Range(min, max);
    }

    int RandomizerInt(int min = 1, int max = 1000)
    {
        return Random.Range(min, max);
    }

    private IEnumerator SpawnDelay()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnDelay);
        canSpawn = true;
    }

}
