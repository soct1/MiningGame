using System;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] private FloorData[] floors;
    [SerializeField] private MineSpawner mineSpawner;
    [SerializeField] private FloorProgression floorProgression;
    [SerializeField] private Transform player;
    [SerializeField] private Transform floorSpawnPoint;
    public event Action<int> FloorChanged;
    public int FloorCount => floors.Length;
    private int activeFloorIndex = -1;

    public int ActiveFloorIndex => activeFloorIndex;

    private void Start()
    {
        mineSpawner.FloorCleared += OnFloorCleared;

        ChangeFloor(0);
    }

    private void OnDestroy()
    {
        if (mineSpawner != null)
        {
            mineSpawner.FloorCleared -= OnFloorCleared;
        }
    }

    public void ChangeFloor(int floorIndex)
    {
        if (floorIndex < 0 || floorIndex >= floors.Length)
            return;

        if (floorIndex == activeFloorIndex)
            return;

        if (floorProgression != null &&
            !floorProgression.IsFloorUnlocked(floorIndex))
            return;

        activeFloorIndex = floorIndex;

        player.position = floorSpawnPoint.position;

        mineSpawner.SpawnFloor(floors[activeFloorIndex]);

        FloorChanged?.Invoke(activeFloorIndex);
    }

    private void OnFloorCleared()
    {
        if (floorProgression == null)
            return;

        floorProgression.RegisterFloorClear(activeFloorIndex);
    }
}