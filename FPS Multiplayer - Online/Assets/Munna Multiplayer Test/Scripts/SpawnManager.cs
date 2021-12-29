using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    SpawnPoints[] spawnPoints;

    private void Awake()
    {
        instance = this;
        spawnPoints = GetComponentsInChildren<SpawnPoints>();
    }

    public Transform GetSpawnPoints() 
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
    }
}
