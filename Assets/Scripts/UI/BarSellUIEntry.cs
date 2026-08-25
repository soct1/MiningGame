using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarSellUIEntry : MonoBehaviour
{
    [SerializeField] private TMP_Text barText;
    [SerializeField] private TMP_Text valueText;
    [SerializeField] private Button sellButton;

    private BarSellSystem sellSystem;
    private BarInventory barInventory;
    private BarData bar;

    public void Initialize(
        BarSellSystem system,
        BarInventory inventory,
        BarData barData)
    {
        sellSystem = system;
        barInventory = inventory;
        bar = barData;

        if (barInventory != null)
            barInventory.BarChanged += OnBarChanged;

        if (sellButton != null)
        {
            sellButton.onClick.RemoveAllListeners();
            sellButton.onClick.AddListener(Sell);
        }

        Refresh();
    }

    private void OnDestroy()
    {
        if (barInventory != null)
            barInventory.BarChanged -= OnBarChanged;

        if (sellButton != null)
            sellButton.onClick.RemoveListener(Sell);
    }

    private void OnBarChanged(BarData changedBar)
    {
        if (changedBar == bar)
            Refresh();
    }

    private void Sell()
    {
        if (sellSystem == null || bar == null)
            return;

        sellSystem.Sell(bar, 1);
    }

    private void Refresh()
    {
        if (bar == null || barInventory == null)
            return;

        int amount = barInventory.GetAmount(bar);

        if (barText != null)
        {
            barText.text =
                $"{bar.BarName}: {amount}";
        }

        if (valueText != null)
        {
            valueText.text =
                $"{bar.SellValue} {bar.SellCurrencyId}";
        }

        if (sellButton != null)
        {
            sellButton.interactable = amount > 0;
        }
    }
}