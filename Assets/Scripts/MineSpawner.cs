using System;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private MiningArea miningArea;
    [SerializeField] private GameObject minePrefab;

    [Header("Spawn Settings")]
    [SerializeField] private float minimumSpawnDistance = 1.2f;
    [SerializeField] private int maxSpawnAttempts = 100;

    private readonly List<Vector2> spawnedPositions = new();
    private readonly List<Mine> activeMines = new();
    private FloorData activeFloor;
    public event Action FloorCleared;
    public void SpawnFloor(FloorData floor)
    {
        if (floor == null)
        {
            Debug.LogWarning("SpawnFloor: FloorData bulunamadı.");
            return;
        }

        ClearMines();

        activeFloor = floor;

        SpawnMines();

    }

    private void Update()
    {
        if (activeFloor == null)
            return;

        RemoveDestroyedMines();

        if (activeMines.Count == 0)
        {
            FloorCleared?.Invoke();

            if (activeMines.Count > 0)
                return;

            SpawnMines();
        }
    }

    private MineData GetRandomMineData()
    {
        FloorMineEntry[] entries = activeFloor.MineEntries;

        if (entries == null || entries.Length == 0)
            return null;

        int totalWeight = 0;

        foreach (FloorMineEntry entry in entries)
        {
            if (entry != null && entry.MineData != null && entry.Weight > 0)
            {
                totalWeight += entry.Weight;
            }
        }

        if (totalWeight <= 0)
            return null;

        int randomValue = UnityEngine.Random.Range(0, totalWeight);
        int currentWeight = 0;

        foreach (FloorMineEntry entry in entries)
        {
            if (entry == null || entry.MineData == null || entry.Weight <= 0)
                continue;

            currentWeight += entry.Weight;

            if (randomValue < currentWeight)
                return entry.MineData;
        }

        return null;
    }

    private void SpawnMines()
    {
        Debug.Log(
            $"[MineSpawner] SpawnMines ÇAĞRILDI → " +
            $"Floor: {activeFloor?.name} | " +
            $"MineCount: {activeFloor?.MineCount}"
        );

        if (activeFloor == null)
            return;

        spawnedPositions.Clear();

        for (int i = 0; i < activeFloor.MineCount; i++)
        {
            if (!TryGetSpawnPosition(out Vector2 spawnPosition))
            {
                Debug.LogWarning(
                    $"Mine {i + 1} için uygun spawn pozisyonu bulunamadı."
                );

                break;
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

            MineData randomMine = GetRandomMineData();

            if (randomMine != null)
                mine.SetData(randomMine);

            activeMines.Add(mine);
        }
    }

    private void ClearMines()
    {
        foreach (Mine mine in activeMines)
        {
            if (mine != null)
            {
                Destroy(mine.gameObject);
            }
        }

        activeMines.Clear();
        spawnedPositions.Clear();
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