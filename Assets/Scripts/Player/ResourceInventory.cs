using System.Collections.Generic;
using UnityEngine;

public class ResourceInventory : MonoBehaviour
{
    private readonly Dictionary<ResourceData, int> resources = new();

    public int GetAmount(ResourceData resource)
    {
        if (resource == null)
            return 0;

        return resources.TryGetValue(resource, out int amount)
            ? amount
            : 0;
    }

    public void Add(ResourceData resource, int amount)
    {
        if (resource == null || amount <= 0)
            return;

        if (resources.ContainsKey(resource))
        {
            resources[resource] += amount;
        }
        else
        {
            resources.Add(resource, amount);
        }
        Debug.Log($"[ResourceInventory] +{amount} {resource.name} | Toplam: {resources[resource]}");
    }
}