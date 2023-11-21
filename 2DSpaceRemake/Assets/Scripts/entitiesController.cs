using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entitiesController : MonoBehaviour
{
    #region singleton
    public static entitiesController Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    public GameObject[] asteroidPrefabs;
    public float asteroidSpawnDistance = 50f;

    public float spawnTime = 2f;
    public float Timer = 0f;

    [HideInInspector]
    public float minX, maxX, minY, maxY;

    public void Start()
    {
        Timer = spawnTime;
    }

    public void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= spawnTime)
        {
            // spawn asteroids
            spawnNewAsteroid();
            Timer = 0f;
        }
    }

    public void spawnNewAsteroid()
    {
        float newX = Random.Range(minX, maxX);
        float newY = Random.Range(minY, maxY);

        Vector3 spawPos = new Vector3(newX, newY, asteroidSpawnDistance);

        Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], spawPos, Quaternion.identity);
    }

}
