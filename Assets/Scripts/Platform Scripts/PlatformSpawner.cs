using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;
    public float platformSpawnTimer = 1.8f;
    private float currentPlatformSpawnTimer;
    private int platformSpawnCount;
    public float minX = -2f, maxX = 2f;
    // Start is called before the first frame update
    void Start()
    {
        currentPlatformSpawnTimer = platformSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        spawnPlatforms();
    }

    void spawnPlatforms()
    {
        currentPlatformSpawnTimer += Time.deltaTime;
        if (currentPlatformSpawnTimer >= platformSpawnTimer)
        {
            //Spawn platforms
            platformSpawnCount++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);
            GameObject newPlatform = null;
            if (platformSpawnCount < 2)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }else if (platformSpawnCount == 2)
            {
                if(Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(movingPlatforms[Random.Range(0, movingPlatforms.Length)], temp, Quaternion.identity);
                }
            }else if (platformSpawnCount == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);
                }
                platformSpawnCount = 0;
            }
            newPlatform.transform.parent = transform;
            currentPlatformSpawnTimer = 0f;
        }
    }
}
