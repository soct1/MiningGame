using System;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyInventory : MonoBehaviour
{
    private readonly Dictionary<string, int> currencies = new();

    public event Action<string> CurrencyChanged;

    public int GetAmount(string currencyId)
    {
        if (string.IsNullOrEmpty(currencyId))
            return 0;

        return currencies.TryGetValue(currencyId, out int amount)
            ? amount
            : 0;
    }

    public void Add(string currencyId, int amount)
    {
        if (string.IsNullOrEmpty(currencyId) || amount <= 0)
            return;

        if (currencies.ContainsKey(currencyId))
            currencies[currencyId] += amount;
        else
            currencies.Add(currencyId, amount);

        Debug.Log(
            $"[CurrencyInventory] +{amount} {currencyId} | " +
            $"Toplam: {currencies[currencyId]}"
        );

        CurrencyChanged?.Invoke(currencyId);
    }

    public bool Remove(string currencyId, int amount)
    {
        if (string.IsNullOrEmpty(currencyId) || amount <= 0)
            return false;

        if (!currencies.TryGetValue(currencyId, out int currentAmount))
            return false;

        if (currentAmount < amount)
            return false;

        currencies[currencyId] -= amount;

        Debug.Log(
            $"[CurrencyInventory] -{amount} {currencyId} | " +
            $"Toplam: {currencies[currencyId]}"
        );

        CurrencyChanged?.Invoke(currencyId);

        return true;
    }
}