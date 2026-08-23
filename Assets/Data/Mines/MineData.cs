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

    [Header("Resource")]
    [SerializeField] private string resourceId;

    public string MineName => mineName;
    public float MaxHP => maxHP;
    public float Hardness => hardness;
    public string ResourceId => resourceId;
}