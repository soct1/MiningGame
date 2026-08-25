using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    [SerializeField] private OreInventory oreInventory;
    [SerializeField] private BarInventory barInventory;

    private void Awake()
    {
        if (oreInventory == null)
            oreInventory = FindAnyObjectByType<OreInventory>();

        if (barInventory == null)
            barInventory = FindAnyObjectByType<BarInventory>();
    }

    public bool Craft(CraftingRecipe recipe)
    {
        if (recipe == null)
            return false;

        if (oreInventory == null || barInventory == null)
            return false;

        bool removed = oreInventory.Remove(
            recipe.InputOre,
            recipe.InputAmount
        );

        if (!removed)
        {
            Debug.Log(
                $"[CraftingSystem] Yetersiz Ore: " +
                $"{recipe.InputOre.name}"
            );

            return false;
        }

        barInventory.Add(
            recipe.OutputBar,
            recipe.OutputAmount
        );

        Debug.Log(
            $"[CraftingSystem] Crafted: " +
            $"{recipe.InputAmount} {recipe.InputOre.name} → " +
            $"{recipe.OutputAmount} {recipe.OutputBar.name}"
        );

        return true;
    }
}