using UnityEngine;

public class BarSellSystem : MonoBehaviour
{
    [SerializeField] private BarInventory barInventory;
    [SerializeField] private CurrencyInventory currencyInventory;

    private void Awake()
    {
        if (barInventory == null)
            barInventory = FindAnyObjectByType<BarInventory>();

        if (currencyInventory == null)
            currencyInventory = FindAnyObjectByType<CurrencyInventory>();
    }

    public bool Sell(BarData bar, int amount)
    {
        if (bar == null || amount <= 0)
            return false;

        if (barInventory == null || currencyInventory == null)
            return false;

        int totalValue = bar.SellValue * amount;

        bool removed = barInventory.Remove(bar, amount);

        if (!removed)
        {
            Debug.Log(
                $"[BarSellSystem] Yetersiz Bar: {bar.BarName}"
            );

            return false;
        }

        currencyInventory.Add(
            bar.SellCurrencyId,
            totalValue
        );

        Debug.Log(
            $"[BarSellSystem] Sold: " +
            $"{amount}x {bar.BarName} → " +
            $"+{totalValue} {bar.SellCurrencyId}"
        );

        return true;
    }
}