using System;
using UnityEngine;

public class FloorProgression : MonoBehaviour
{
    [SerializeField] private int floorCount = 4;
    [SerializeField] private int clearsPerFloor = 3;

    private int[] completedClears;

    public event Action<int> FloorProgressChanged;
    public event Action<int> FloorUnlocked;

    private void Awake()
    {
        floorCount = Mathf.Max(1, floorCount);
        clearsPerFloor = Mathf.Max(1, clearsPerFloor);

        completedClears = new int[floorCount];
    }

    public int GetCompletedClears(int floorIndex)
    {
        if (!IsValidFloor(floorIndex))
            return 0;

        return completedClears[floorIndex];
    }

    public int GetRequiredClears(int floorIndex)
    {
        if (!IsValidFloor(floorIndex))
            return 0;

        return (floorIndex + 1) * clearsPerFloor;
    }

    public bool IsFloorUnlocked(int floorIndex)
    {
        if (!IsValidFloor(floorIndex))
            return false;

        if (floorIndex == 0)
            return true;

        return completedClears[floorIndex - 1] >=
               GetRequiredClears(floorIndex - 1);
    }

    public void RegisterFloorClear(int floorIndex)
    {
        if (!IsValidFloor(floorIndex))
            return;

        int requiredClears = GetRequiredClears(floorIndex);

        // Progress tamamlanmadıysa artır.
        if (completedClears[floorIndex] < requiredClears)
        {
            completedClears[floorIndex]++;

            Debug.Log(
                $"[FloorProgression] Floor {floorIndex + 1} Clear: " +
                $"{completedClears[floorIndex]} / {requiredClears}"
            );

            FloorProgressChanged?.Invoke(floorIndex);
        }
        else
        {
            // Progress zaten tamamlandı ama yeni tur gerçekten tamamlandı.
            Debug.Log(
                $"[FloorProgression] Floor {floorIndex + 1} Clear: " +
                $"Progress zaten tamamlandı ({requiredClears} / {requiredClears})"
            );
        }

        int nextFloor = floorIndex + 1;

        if (nextFloor < floorCount &&
            completedClears[floorIndex] >= requiredClears)
        {
            // Sadece kilitli durumdan açılma işlemi.
            if (!IsFloorUnlocked(nextFloor))
            {
                Debug.Log(
                    $"[FloorProgression] Floor {nextFloor + 1} UNLOCKED!"
                );

                FloorUnlocked?.Invoke(nextFloor);
            }
            else
            {
                // Kat zaten açıksa AUTO yine bu event'e ihtiyaç duyabilir.
                FloorUnlocked?.Invoke(nextFloor);
            }
        }
    }

    private bool IsValidFloor(int floorIndex)
    {
        return floorIndex >= 0 && floorIndex < floorCount;
    }
}