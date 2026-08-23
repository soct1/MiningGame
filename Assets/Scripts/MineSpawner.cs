using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private MiningArea miningArea;
    [SerializeField] private GameObject minePrefab;

    [SerializeField] private int mineCount = 10;
    [SerializeField] private float minimumSpawnDistance = 0.7f;
    [SerializeField] private int maxSpawnAttempts = 100;

    private readonly List<Vector2> spawnedPositions = new();

    private void Start()
    {
        SpawnMines();
    }

    private void SpawnMines()
    {
        spawnedPositions.Clear();

        for (int i = 0; i < mineCount; i++)
        {
            if (!TryGetSpawnPosition(out Vector2 spawnPosition))
            {
                Debug.LogWarning(
                    $"Mine {i + 1} için uygun spawn pozisyonu bulunamadı."
                );

                return;
            }

            spawnedPositions.Add(spawnPosition);

            Instantiate(
                minePrefab,
                spawnPosition,
                Quaternion.identity,
                transform
            );
        }
    }

    private bool TryGetSpawnPosition(out Vector2 spawnPosition)
    {
        for (int attempt = 0; attempt < maxSpawnAttempts; attempt++)
        {
            Vector2 candidate = miningArea.GetRandomPosition();

            bool positionIsValid = true;

            foreach (Vector2 existingPosition in spawnedPositions)
            {
                if (Vector2.Distance(candidate, existingPosition) < minimumSpawnDistance)
                {
                    positionIsValid = false;
                    break;
                }
            }

            if (positionIsValid)
            {
                spawnPosition = candidate;
                return true;
            }
        }

        spawnPosition = default;
        return false;
    }
}