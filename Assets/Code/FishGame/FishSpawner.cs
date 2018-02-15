using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    public Fish[] fishes;
    public GameObject fishPrefab;

    [Header("Randomizer")] public float spawnChance = 500;

    private void FixedUpdate()
    {
        if (RandomizerFloat(1, 500) < 5)
        {
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

}
