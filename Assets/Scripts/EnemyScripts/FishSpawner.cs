using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    public Fish[] fishes;

    [Header("Spawning")]
    [Range(0, 100)] public float spawnChance = 25;
    [Range(0, 5)] public float spawnDelay = 0.25f;
    [Range(0, 10)] public float maxTimeToSpawn = 5;
    [Range(1, 20)] public int destroyDelay = 5;

    private bool canSpawn = true;
    private float lastSpawnTime = 0;

    private void Start()
    {
        float spawnSum = 0;
        foreach (Fish fish in fishes)
        {
            spawnSum += fish.spawnChance;
        }
        if (spawnSum > 100)
        {
            float toSubtract = (spawnSum - 100) / fishes.Length;
            foreach (Fish fish in fishes)
            {
                fish.spawnChance -= toSubtract;
            }
        }
    }

    private void FixedUpdate()
    {
        if ((Time.time > lastSpawnTime + maxTimeToSpawn)
            || (canSpawn && RandomizerFloat(0, 100) < spawnChance))
        {
            lastSpawnTime = Time.time;
            StartCoroutine(SpawnDelay());
            Vector3 spawnPos = new Vector3(transform.position.x,
                                            transform.position.y + (RandomizerFloat(0, Camera.main.orthographicSize - 1) * RandomInvert()),
                                            transform.position.z);
            Fish selectedFish = fishes[SpawnFish()];
            GameObject spawnedFish = Instantiate(selectedFish.prefab, spawnPos, transform.rotation, transform);
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
        return Random.Range(0f, 1f) < 0.5 ? 1 : -1;
    }

    private IEnumerator SpawnDelay()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnDelay);
        canSpawn = true;
    }

    private int SpawnFish()
    {
        float thing = RandomizerFloat(0f, 100f);
        float total = 0;

        for (int i = 0; i < fishes.Length; i++)
        {
            total += fishes[i].spawnChance;
            if (total >= thing)
            {
                return i;
            }
        }
        return 0;
    }

}
