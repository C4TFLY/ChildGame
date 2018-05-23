using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    public Fish[] fishes;

    [Header("Spawning")]
    [Range(0, 100)] public float spawnChance = 25;
    [Range(0, 5)] public float spawnDelay = 0.25f;
    [Range(0, 10)] public float maxTimeToSpawn = 5;

    private bool canSpawn = true;
    private float lastSpawnTime = 0;

    private void Start()
    {
        //Lägg ihop alla fienders "spawnChance" och ta bort den mängd som flödar över 100

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

        if ((Time.time > lastSpawnTime + maxTimeToSpawn) //Om mer tid än den högsta tillåtna gått sedan senaste spawn
            || (canSpawn && RandomizerFloat(0, 100) < spawnChance)) // Eller om slumpgeneratorn slår under gränsen
        {
            lastSpawnTime = Time.time;
            StartCoroutine(SpawnDelay());
            Vector3 spawnPos = new Vector3(transform.position.x,
                                            transform.position.y + (RandomizerFloat(0, Camera.main.orthographicSize - 1) * RandomInvert()),
                                            transform.position.z);
            Fish selectedFish = fishes[SpawnFish()]; //Välj en fisk från arrayen
            GameObject spawnedFish = Instantiate(selectedFish.prefab, spawnPos, transform.rotation, transform); //Instansiera en fiende från dess "prefab"-egenskap
            spawnedFish.GetComponent<EnemyFish>().properties = selectedFish; //Kopiera den valda fiskens egenskaper till den instansierade fisken
            spawnedFish.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * selectedFish.moveSpeed * 10); //Skjutsa iväg fisken med dess hastighet
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

    /// <summary>
    /// Randomly decide on inverting a number
    /// </summary>
    /// <returns>1 or -1 to invert or not invert</returns>
    int RandomInvert()
    {
        return Random.Range(0f, 1f) < 0.5 ? 1 : -1; //Välj på slump om 1 eller -1 ska skickas tillbaka
    }

    /// <summary>
    /// Stop enemies from spawning for a minimum amount of time
    /// </summary>
    private IEnumerator SpawnDelay()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnDelay);
        canSpawn = true;
    }

    /// <summary>
    /// Spawn a fish dependent on it's spawnChance property
    /// </summary>
    /// <returns>Place in the array</returns>
    private int SpawnFish()
    {
        float thing = RandomizerFloat(0f, 100f); //Slumpa ett tal
        float total = 0;

        for (int i = 0; i < fishes.Length; i++)
        {
            total += fishes[i].spawnChance; //Lägg ihop fiskarnas spawnChance
            if (total >= thing)
            {
                return i; //Om den totala mängden spawnChance uppnår det slumpade talet, skicka tillbaka fiskens plats i arrayen
            }
        }
        return 0;
    }

}
