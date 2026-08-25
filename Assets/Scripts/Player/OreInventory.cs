using System;
using System.Collections.Generic;
using UnityEngine;

public class OreInventory : MonoBehaviour
{
    private readonly Dictionary<OreData, int> resources = new();

    public event Action<OreData> OreChanged;

    public int GetAmount(OreData ore)
    {
        if (ore == null)
            return 0;

        return resources.TryGetValue(ore, out int amount)
            ? amount
            : 0;
    }

    public void Add(OreData ore, int amount)
    {
        if (ore == null || amount <= 0)
            return;

        if (resources.ContainsKey(ore))
        {
            resources[ore] += amount;
        }
        else
        {
            resources.Add(ore, amount);
        }

        Debug.Log(
            $"[ResourceInventory] +{amount} {ore.name} | " +
            $"Toplam: {resources[ore]}"
        );

        OreChanged?.Invoke(ore);
    }

    public bool Remove(OreData ore, int amount)
    {
        if (ore == null || amount <= 0)
            return false;

        if (!resources.TryGetValue(ore, out int currentAmount))
            return false;

        if (currentAmount < amount)
            return false;

        resources[ore] -= amount;

        Debug.Log(
            $"[ResourceInventory] -{amount} {ore.name} | " +
            $"Toplam: {resources[ore]}"
        );

        OreChanged?.Invoke(ore);

        return true;
    }
}