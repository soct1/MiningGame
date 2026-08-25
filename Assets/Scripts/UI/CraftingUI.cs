using UnityEngine;

public class CraftingUI : MonoBehaviour
{
    [SerializeField] private CraftingSystem craftingSystem;
    [SerializeField] private OreInventory oreInventory;
    [SerializeField] private BarInventory barInventory;

    [Header("Recipes")]
    [SerializeField] private CraftingRecipe[] recipes;

    [Header("UI")]
    [SerializeField] private Transform container;
    [SerializeField] private CraftingUIEntry entryPrefab;

    private void Start()
    {
        if (craftingSystem == null)
            craftingSystem = FindAnyObjectByType<CraftingSystem>();

        if (oreInventory == null)
            oreInventory = FindAnyObjectByType<OreInventory>();

        if (barInventory == null)
            barInventory = FindAnyObjectByType<BarInventory>();

        CreateEntries();
    }

    private void CreateEntries()
    {
        if (container == null ||
            entryPrefab == null ||
            craftingSystem == null ||
            oreInventory == null ||
            barInventory == null)
            return;

        foreach (CraftingRecipe recipe in recipes)
        {
            if (recipe == null)
                continue;

            CraftingUIEntry entry =
                Instantiate(entryPrefab, container);

            entry.Initialize(
                craftingSystem,
                recipe,
                oreInventory,
                barInventory
            );
        }
    }
}