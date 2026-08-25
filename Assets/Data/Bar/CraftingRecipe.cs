using UnityEngine;

[CreateAssetMenu(
    fileName = "CraftingRecipe",
    menuName = "CultOfTheMine/Crafting Recipe"
)]
public class CraftingRecipe : ScriptableObject
{
    [Header("Recipe")]
    [SerializeField] private OreData inputOre;
    [SerializeField] private int inputAmount = 10;

    [Header("Output")]
    [SerializeField] private BarData outputBar;
    [SerializeField] private int outputAmount = 1;

    public OreData InputOre => inputOre;
    public int InputAmount => inputAmount;

    public BarData OutputBar => outputBar;
    public int OutputAmount => outputAmount;
}