using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] private FloorData[] floors;
    [SerializeField] private MineSpawner mineSpawner;
    [SerializeField] private Transform player;
    [SerializeField] private Transform floorSpawnPoint;

    private int activeFloorIndex;

    private void Start()
    {
        ChangeFloor(0);
    }

    public void ChangeFloor(int floorIndex)
    {
        if (floorIndex < 0 || floorIndex >= floors.Length)
            return;

        activeFloorIndex = floorIndex;

        player.position = floorSpawnPoint.position;

        mineSpawner.SpawnFloor(floors[activeFloorIndex]);
    }

    public void TestFloor1()
    {
        ChangeFloor(0);
    }
    public void TestFloor2()
    {
        ChangeFloor(1);
    }

    public void TestFloor3()
    {
        ChangeFloor(2);
    }

    public void TestFloor4()
    {
        ChangeFloor(3);
    }
}