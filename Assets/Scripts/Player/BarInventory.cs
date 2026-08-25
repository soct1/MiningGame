using System;
using System.Collections.Generic;
using UnityEngine;

public class BarInventory : MonoBehaviour
{
    private readonly Dictionary<BarData, int> bars = new();

    public event Action<BarData> BarChanged;

    public int GetAmount(BarData bar)
    {
        if (bar == null)
            return 0;

        return bars.TryGetValue(bar, out int amount)
            ? amount
            : 0;
    }

    public void Add(BarData bar, int amount)
    {
        if (bar == null || amount <= 0)
            return;

        if (bars.ContainsKey(bar))
        {
            bars[bar] += amount;
        }
        else
        {
            bars.Add(bar, amount);
        }

        Debug.Log(
            $"[BarInventory] +{amount} {bar.name} | " +
            $"Toplam: {bars[bar]}"
        );

        BarChanged?.Invoke(bar);
    }

    public bool Remove(BarData bar, int amount)
    {
        if (bar == null || amount <= 0)
            return false;

        if (!bars.TryGetValue(bar, out int currentAmount))
            return false;

        if (currentAmount < amount)
            return false;

        bars[bar] -= amount;

        Debug.Log(
            $"[BarInventory] -{amount} {bar.name} | " +
            $"Toplam: {bars[bar]}"
        );

        BarChanged?.Invoke(bar);

        return true;
    }
}