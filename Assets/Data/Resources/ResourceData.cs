using UnityEngine;

[CreateAssetMenu(
    fileName = "ResourceData",
    menuName = "CultOfTheMine/Resource Data"
)]
public class ResourceData : ScriptableObject
{
    [SerializeField] private string resourceName;

    public string ResourceName => resourceName;
}