using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider))]
public class DuckSpawner : MonoBehaviour
{
    [Serializable]
    public class Path
    {
        public List<Transform> points;
    }

    [Header("Prefab & Paths")]
    [SerializeField] private GameObject duckPrefab;
    [SerializeField] private List<Path> paths;

    [Header("Spawn & Difficulty")]
    [SerializeField] private float initialSpawnInterval = 3f;
    [SerializeField] private float minSpawnInterval = 0.5f;
    [SerializeField] private float spawnIntervalDecrease = 0.2f;
    [SerializeField] private float difficultyIncreaseInterval = 30f;

    private BoxCollider spawnArea;
    private float currentSpawnInterval;
    private float difficultyTimer;

    private void Awake()
    {
        spawnArea = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        if (paths == null || paths.Count == 0)
            Debug.LogError("DuckSpawner: Debes asignar al menos una ruta en Paths.");

        currentSpawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnRoutine());
        GameManager.Instance.OnGameOver += StopSpawning;
    }
    

    private IEnumerator SpawnRoutine()
    {
        while (!GameManager.Instance.IsGameOver)
        {
            SpawnDuck();
            yield return new WaitForSeconds(currentSpawnInterval);

            difficultyTimer += currentSpawnInterval;
            if (difficultyTimer >= difficultyIncreaseInterval)
            {
                currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - spawnIntervalDecrease);
                difficultyTimer = 0f;
            }
        }
    }

    private void SpawnDuck()
    {
        // Elige ruta aleatoria
        int routeIndex = Random.Range(0, paths.Count);
        List<Transform> chosenPath = paths[routeIndex].points;

        if (chosenPath == null || chosenPath.Count == 0)
        {
            Debug.LogWarning("DuckSpawner: Ruta vacía en index " + routeIndex);
            return;
        }

        // Spawn en el primer punto de la ruta
        Vector3 spawnPosition = chosenPath[0].position;
        GameObject duck = Instantiate(duckPrefab, spawnPosition, Quaternion.identity);

        if (duck.TryGetComponent<PatoMovement>(out var mover))
            mover.Initialize(chosenPath);
    }

    private void StopSpawning() => StopAllCoroutines();
}
