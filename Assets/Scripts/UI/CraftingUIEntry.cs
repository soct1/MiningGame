using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUIEntry : MonoBehaviour
{
    [SerializeField] private TMP_Text inputText;
    [SerializeField] private TMP_Text outputText;
    [SerializeField] private Button craftButton;

    private CraftingSystem craftingSystem;
    private CraftingRecipe recipe;

    private OreInventory oreInventory;
    private BarInventory barInventory;

    public void Initialize(
        CraftingSystem system,
        CraftingRecipe craftingRecipe,
        OreInventory oreInventory,
        BarInventory barInventory)
    {
        craftingSystem = system;
        recipe = craftingRecipe;

        this.oreInventory = oreInventory;
        this.barInventory = barInventory;

        if (this.oreInventory != null)
            this.oreInventory.OreChanged += OnOreChanged;

        craftButton.onClick.RemoveAllListeners();
        craftButton.onClick.AddListener(Craft);

        Refresh();
    }

    private void OnDestroy()
    {
        if (oreInventory != null)
            oreInventory.OreChanged -= OnOreChanged;
    }

    private void OnOreChanged(OreData ore)
    {
        if (recipe == null)
            return;

        if (ore == recipe.InputOre)
            Refresh();
    }

    private void Craft()
    {
        if (craftingSystem == null || recipe == null)
            return;

        craftingSystem.Craft(recipe);
        Refresh();
    }

    private void Refresh()
    {
        if (recipe == null ||
            oreInventory == null ||
            barInventory == null)
            return;

        if (recipe.InputOre == null ||
            recipe.OutputBar == null)
            return;

        int oreAmount =
            oreInventory.GetAmount(recipe.InputOre);

        int barAmount =
            barInventory.GetAmount(recipe.OutputBar);

        if (inputText != null)
        {
            inputText.text =
                $"{recipe.InputOre.OreName}: " +
                $"{oreAmount} / {recipe.InputAmount}";
        }

        if (outputText != null)
        {
            outputText.text =
                $"{recipe.OutputBar.BarName}: " +
                $"{barAmount}";
        }

        if (craftButton != null)
        {
            craftButton.interactable =
                oreAmount >= recipe.InputAmount;
        }
    }
}