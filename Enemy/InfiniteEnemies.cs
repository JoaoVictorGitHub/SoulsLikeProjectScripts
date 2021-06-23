using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteEnemies : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    public int amnTilesOnScreen = 5;
    private int lastPrefabIndex = 0;
    public Transform spawnZ;

    public float spawnRate = 1f;
    private float nextSpawnTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //playerTransform = GameObject.FindGameObjectsWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTile();
    }


    public void SpawnTile()
    {
        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + 1f / spawnRate;
            GameObject go;

            go = Instantiate(tilePrefabs[RandomPrefabIndex()], spawnZ.position, spawnZ.rotation) as GameObject;
        }


    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
