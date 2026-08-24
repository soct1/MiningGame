using UnityEngine;

[System.Serializable]
public class FloorMineEntry
{
    [SerializeField] private MineData mineData;
    [SerializeField] private int weight = 1;

    public MineData MineData => mineData;
    public int Weight => weight;
}