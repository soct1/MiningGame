using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private MiningArea miningArea;
    [SerializeField] private GameObject minePrefab;

    [Header("Floor Mines")]
    [SerializeField] private MineData[] availableMines;

    [Header("Spawn Settings")]
    [SerializeField] private int mineCount = 10;
    [SerializeField] private float minimumSpawnDistance = 1.2f;
    [SerializeField] private int maxSpawnAttempts = 100;

    private readonly List<Vector2> spawnedPositions = new();
    private readonly List<Mine> activeMines = new();

    private void Start()
    {
        SpawnMines();
    }

    private void Update()
    {
        RemoveDestroyedMines();

        if (activeMines.Count == 0)
        {
            SpawnMines();
        }
    }

    private void SpawnMines()
    {
        spawnedPositions.Clear();
        activeMines.Clear();

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

            GameObject mineObject = Instantiate(
                minePrefab,
                spawnPosition,
                Quaternion.identity,
                transform
            );

            Mine mine = mineObject.GetComponent<Mine>();

            if (mine == null)
                continue;

            if (availableMines.Length > 0)
            {
                MineData randomMine =
                    availableMines[Random.Range(0, availableMines.Length)];

                mine.SetData(randomMine);
            }

            activeMines.Add(mine);
        }
    }

    private void RemoveDestroyedMines()
    {
        activeMines.RemoveAll(mine => mine == null);
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