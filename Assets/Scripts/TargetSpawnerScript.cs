using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] targetPrefabs; 
    [SerializeField] private Transform[] spawnPoints;     
    [SerializeField] private float minSpawnDelay = 1.5f;
    [SerializeField] private float maxSpawnDelay = 3.5f;
    [SerializeField] private int maxActiveTargets = 5;    // évite d'en spawn trop si le joueur ne tire pas assez vite

    private readonly List<GameObject> activeTargets = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            activeTargets.RemoveAll(t => t == null); // nettoie les cibles déjà détruites

            if (activeTargets.Count < maxActiveTargets)
            {
                SpawnTarget();
            }

            float delay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(delay);
        }
    }

    private void SpawnTarget()
    {
        if (targetPrefabs.Length == 0 || spawnPoints.Length == 0) return;

        GameObject prefab = targetPrefabs[Random.Range(0, targetPrefabs.Length)];
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject target = Instantiate(prefab, point.position, point.rotation);
        activeTargets.Add(target);
    }
}
