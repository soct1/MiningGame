using TMPro;
using UnityEngine;

public class CurrencyUIEntry : MonoBehaviour
{
    [SerializeField] private TMP_Text currencyText;

    private CurrencyInventory currencyInventory;
    private string currencyId;

    public void Initialize(
        CurrencyInventory inventory,
        string id)
    {
        currencyInventory = inventory;
        currencyId = id;

        if (currencyInventory != null)
            currencyInventory.CurrencyChanged += OnCurrencyChanged;

        Refresh();
    }

    private void OnDestroy()
    {
        if (currencyInventory != null)
            currencyInventory.CurrencyChanged -= OnCurrencyChanged;
    }

    private void OnCurrencyChanged(string changedCurrencyId)
    {
        if (changedCurrencyId == currencyId)
            Refresh();
    }

    private void Refresh()
    {
        if (currencyInventory == null ||
            string.IsNullOrEmpty(currencyId))
            return;

        int amount =
            currencyInventory.GetAmount(currencyId);

        if (currencyText != null)
        {
            currencyText.text =
                $"{currencyId}: {amount}";
        }
    }
}