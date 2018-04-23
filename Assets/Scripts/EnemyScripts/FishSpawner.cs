using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    public Fish[] fishes;
    public GameObject fishPrefab;

    [Header("Spawning")] public float spawnChance = 500;
    [Range(0, 5)] public float spawnDelay = 0.25f;
    [Range(0, 10)] public float maxTime = 5;
    [Range(1, 20)] public int destroyDelay = 5;

    private bool canSpawn = true;
    private float lastSpawnTime = 0;

    private void FixedUpdate()
    {
        if ((Time.time > lastSpawnTime + maxTime) || (canSpawn && RandomizerFloat(1, spawnChance) < 5))
        {
            lastSpawnTime = Time.time;
            StartCoroutine(SpawnDelay());
            Vector3 spawnPos = new Vector3(transform.position.x,
                                            transform.position.y + (RandomizerFloat(0, Camera.main.orthographicSize - 1) * RandomInvert()),
                                            transform.position.z);
            GameObject spawnedFish = Instantiate(fishPrefab, spawnPos, transform.rotation, transform);
            Fish selectedFish = fishes[RandomizerInt(0, fishes.Length)];
            spawnedFish.GetComponent<EnemyFish>().properties = selectedFish;
            spawnedFish.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * selectedFish.moveSpeed * 10);
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

    int RandomInvert()
    {
        int inverter = Random.Range(0f, 1f) < 0.5 ? 1 : -1;
        return inverter;
    }

    private IEnumerator SpawnDelay()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnDelay);
        canSpawn = true;
    }

}
