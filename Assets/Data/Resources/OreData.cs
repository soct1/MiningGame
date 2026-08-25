using UnityEngine;

[CreateAssetMenu(
    fileName = "OreData",
    menuName = "CultOfTheMine/Ore Data"
)]
public class OreData : ScriptableObject
{
    [SerializeField] private string oreName;

    public string OreName => oreName;
}