using UnityEngine;

[CreateAssetMenu(
    fileName = "MineData",
    menuName = "CultOfTheMine/Mine Data"
)]
public class MineData : ScriptableObject
{
    [Header("Identity")]
    [SerializeField] private string mineName;

    [Header("Mining")]
    [SerializeField] private float maxHP = 10f;
    [SerializeField] private float hardness = 1f;

    [Header("Ore")]
    [SerializeField] private OreData ore;

    [Header("Experience")]
    [SerializeField] private int experience = 5;

    public string MineName => mineName;
    public float MaxHP => maxHP;
    public float Hardness => hardness;
    public OreData Ore => ore;
    public int Experience => experience;
}