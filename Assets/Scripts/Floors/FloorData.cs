using UnityEngine;

[CreateAssetMenu(
    fileName = "FloorData",
    menuName = "CultOfTheMine/Floor Data"
)]
public class FloorData : ScriptableObject
{
    [SerializeField] private string floorName;
    [SerializeField] private FloorMineEntry[] mineEntries;
    [SerializeField] private int mineCount = 10;

    public string FloorName => floorName;
    public FloorMineEntry[] MineEntries => mineEntries;
    public int MineCount => mineCount;
}